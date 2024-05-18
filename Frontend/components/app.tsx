import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

import TermDefinitionList from './pages/termDefinitionList';
import TermDefinitionAdd from './pages/termDefinitionAdd';
import TermDefinitionEdit from './pages/termDefinitionEdit';

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