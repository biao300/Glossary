import React, { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';

import TextAreaField from 'components/form/textarea';
import { API_URL_TERMS } from '../../shared/consts';


export default function TermDefinitionEdit() {
    const [term, setTerm] = useState("");
    const [termError, setTermError] = useState("");
    const [termTouched, setTermTouched] = useState(false);

    const [definition, setDefinition] = useState("");
    const [definitionError, setDefinitionError] = useState("");
    const [definitionTouched, setDefinitionTouched] = useState(false);

    const [formMessage, setFormMessage] = useState("");

    const [params, setParams] = useSearchParams();

    useEffect(() => {
        fetch(`${API_URL_TERMS}/${params.get(`id`)}`, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            }
        }).then((res) => {
            res.json().then((jres) => {
                console.log("editing term: ", jres);
                if (jres.result.term) {
                    setTerm(jres.result.term);
                    setDefinition(jres.result.definition);
                } else {
                    window.location.href = "/home";
                }
            });
        }).catch((e) => {
            console.log("get term error, reason:", e);
        });
    }, []);

    const checkValidation = ({term, definition}: any) => {
        let termError = "";
        let definitionError = "";

        if (!term && term === "") {
            termError = "Please input term";
        }

        if (!definition && definition === "") {
            definitionError = "Please input definition";
        }

        setTermTouched(true);
        setDefinitionTouched(true);
        setTermError(termError);
        setDefinitionError(definitionError);

        setFormMessage("");

        return termError === "" && definitionError === "";
    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
    
        const editTerm = {
            id: params.get(`id`),
            term: event.target.term.value,
            definition: event.target.definition.value,
        }

        const valid = checkValidation(editTerm);

        if (valid) {
            // call api
            console.log(`call api`);
            fetch(API_URL_TERMS, {
                method: 'PUT',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(editTerm)
            }).then((res) => {
                res.json().then((jres) => {
                    console.log("edit term result: ", jres);
                    setFormMessage(`Update term "${jres.result.Name}" success`);
                });
            }).catch((e) => {
                console.log("Update term error, reason:", e);
            })
        }
    }

    return (<form onSubmit={handleSubmit}>
        <h2>Edit term and definition</h2>
        <TextAreaField 
            name="term"
            input={term}
            label="Term: "
            maxLength={50}
            rows={1}
            cols={50}
            touched={termTouched}
            error={termError}
            handleChange={(e: any) => setTerm(e.currentTarget.value)}
        />
        <TextAreaField 
            name="definition"
            input={definition}
            label="Definition: "
            maxLength={1000}
            rows={20}
            cols={50}
            touched={definitionTouched}
            error={definitionError}
            handleChange={(e: any) => setDefinition(e.currentTarget.value)}
        />

        <p><input type="submit" value='Update' /></p>
        <p>{formMessage}</p>
        <p><a href="/home">Back to Term List</a></p>
    </form>)
}