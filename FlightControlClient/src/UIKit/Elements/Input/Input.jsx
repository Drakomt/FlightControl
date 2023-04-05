import { useState } from 'react';
import './Input.css';

export const Input = ({ value, onChange }) => {
    return (
        <div className="Input">
            <input value={value} onChange={onChange} />
        </div>
    )
}