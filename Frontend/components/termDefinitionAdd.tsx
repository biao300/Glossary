import React, { useState } from 'react';

export default function TermDefinitionAdd() {

    const [term, setTerm] = useState("");
    const [definition, setDefinition] = useState("");

    const handleSubmit = () => {

    }

    return (<form>
        <p>
            <label>Term:</label>
            <textarea 
                name="term"
                maxLength={50}
                style={{resize: 'none'}}
                rows={1}
                cols={50}
                onChange={(e) => setTerm(e.target.value)}
            />
            
        </p>
        <p>
            <label>Definition:</label>
            <textarea 
                name="definition"
                maxLength={1000}
                rows={20}
                cols={50}
                style={{resize: 'none'}}
                onChange={(e) => setDefinition(e.target.value)}
            />
            
        </p>
        <p>
            <button onClick={handleSubmit}>Add</button>
        </p>
        <a href="/home">Back to Term List</a>
      </form>)
}