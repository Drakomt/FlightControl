import { useState } from "react";
import { Rows, Btn } from "UIKit"

export const Counter = () => {
    const [count, setCount] = useState(0);

    const handleAdd = () => {
        setCount(count + 1);
    }
    
    return (
        <Rows>
            <h3>Count: {count}</h3>
            <Btn onClick={handleAdd}>Add</Btn>
        </Rows>
    )
}