import React, { useState } from "react";
import { List, Modal } from 'antd';

const data = [
    {
        term: 'Term 1',
        definition: 'Definition definition 1'
    },
    {
        term: 'Term 2',
        definition: 'Definition definition 2'
    },
    {
        term: 'Term 3',
        definition: 'Definition definition 3'
    },
    {
        term: 'Term 4',
        definition: 'Definition definition 4'
    },
];

export default function TermDefinitionList() {
    const [isModalOpen, setIsModalOpen] = useState(false);

    const showModal = () => {
        setIsModalOpen(true);
    };

    const handleOk = () => {
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    return (<>
        <a href="/home/add">Add new term</a>
        <List
            dataSource={data}
            renderItem={(item) => (
                <List.Item>
                    <List.Item.Meta
                        title={item.term}
                        description={item.definition}
                    />
                    <button onClick={showModal}>Delete</button>
                    <a href="/home/edit">edit</a>
                </List.Item>
            )}
        />
        <Modal title="Delete Term" open={isModalOpen} onOk={handleOk} onCancel={handleCancel}>
            <p>Please confirm...</p>
        </Modal>
    </>);
}