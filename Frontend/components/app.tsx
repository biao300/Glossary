import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

import TermDefinitionList from './termDefinitionList';
import TermDefinitionAdd from './termDefinitionAdd';
import TermDefinitionEdit from './termDefinitionEdit';

export default function App() {
    return(<div>
        <BrowserRouter>
            <Routes>
                <Route index element={<TermDefinitionList />} />
                <Route path="/home/" element={<TermDefinitionList />} />
                <Route path="/home/add" element={<TermDefinitionAdd />} />
                <Route path="/home/edit" element={<TermDefinitionEdit />} />
                <Route path="*" element={<div>page not found</div>} />
            </Routes>
        </BrowserRouter>
    </div>)
}