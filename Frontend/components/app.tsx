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
                <Route path="glossary" element={<TermDefinitionList />} />
                <Route path="glossary/add.html" element={<TermDefinitionAdd />} />
                <Route path="glossary/edit.html" element={<TermDefinitionEdit />} />
                <Route path="*" element={<h1>page not found</h1>} />
            </Routes>
        </BrowserRouter>
    </div>)
}