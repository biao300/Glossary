import React, { useState } from 'react';

import TextAreaField from 'components/form/textarea';
import { API_URL_TERMS } from '../../shared/consts';


export default function TermDefinitionAdd() {

    const [term, setTerm] = useState("");
    const [termError, setTermError] = useState("");
    const [termTouched, setTermTouched] = useState(false);

    const [definition, setDefinition] = useState("");
    const [definitionError, setDefinitionError] = useState("");
    const [definitionTouched, setDefinitionTouched] = useState(false);

    const [formMessage, setFormMessage] = useState("");

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

        const addTerm = {
            term: event.target.term.value,
            definition: event.target.definition.value,
        }

        const valid = checkValidation(addTerm);

        if (valid) {
            // call api
            fetch(API_URL_TERMS, {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(addTerm)
            }).then((res) => {
                res.json().then((jres) => {
                    console.log("add term result: ", jres);
                    setTerm("");
                    setDefinition("");
                    setFormMessage(`Add term "${jres.result.Name}" success`);
                });
            }).catch((e) => {
                console.log("Add term error, reason:", e);
            })
        }
    }

    return (<form onSubmit={handleSubmit}>
        <h2>Add new term and definition</h2>
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

        <p><input type="submit" value='Add' /></p>
        <p>{formMessage}</p>
        <p><a href="/home">Back to Term List</a></p>
    </form>)
}