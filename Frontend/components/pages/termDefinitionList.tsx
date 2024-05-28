import React, { useState, useEffect } from "react";
import { Modal } from 'antd';

import { API_URL_TERMS, ROUTER_URL_TERM_ADD, ROUTER_URL_TERM_EDIT } from '../../shared/consts';

export default function TermDefinitionList() {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [termDefinitionList, setTermDefinitionList] = useState([]);

    const [termIdToDelete, setTermIdToDelete] = useState(0);
    const [modalContent, setModalContent] = useState("");

    const getTermDefinitionList = () => {
        fetch(API_URL_TERMS, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json",
            }
        }).then((res) => {
            console.log("get term list data result 1: ", res);
            res.json().then((jres) => {
                console.log("get term list data result: ", jres);
                setTermDefinitionList(jres.result);
            });
        }).catch((e) => {
            console.log("get term list error, reason:", e);
        });
    }

    useEffect(getTermDefinitionList, []);

    const showModal = (id: number) => {
        setIsModalOpen(true);
        console.log(`confirm deleting term id: ${id}?`);
        setTermIdToDelete(id);
    };

    const handleOk = () => {
        setIsModalOpen(false);
        // call api
        console.log(`deleting term id: ${termIdToDelete}...`);
        fetch(`${API_URL_TERMS}/${termIdToDelete}`, {
            method: 'DELETE',
            headers: {
                "Content-Type": "application/json"
            }
        }).then((res) => {
            res.json().then((jres) => {
                console.log("delete term list data result: ", jres);
                // reload list
                getTermDefinitionList();
                // clear delete id
                setTermIdToDelete(0);
            });
        }).catch((e) => {
            console.log("delete term list error, reason:", e);
        });
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    return (<>
        <h2>List of terms and definitions</h2>
        <a href={ROUTER_URL_TERM_ADD}>Add new term</a>
        <table>
            <thead>
                <tr>
                    <th>Term</th>
                    <th>Definition</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
            {
                termDefinitionList.length > 0 ?
                    termDefinitionList.map((e, index) => {
                        return <tr key={index}>
                            <td>{e.term}</td>
                            <td>{e.definition}</td>
                            <td><a href={`${ROUTER_URL_TERM_EDIT}?id=${e.id}`}>Edit</a></td>
                            <td><button onClick={() => {
                                setModalContent(`Are you sure to delete term "${e.term}" and its definition?`);
                                showModal(e.id);
                            }}>Delete</button></td>
                        </tr>
                    }) : `Loading data...`
            }
            </tbody>
        </table>
        <Modal title="Please Confirm" open={isModalOpen} onOk={handleOk} onCancel={handleCancel}>
            <p>{modalContent}</p>
        </Modal>
    </>);
}