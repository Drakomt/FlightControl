import { useEffect, useRef, useState } from "react"
import { Btn, Rows } from "UIKit"



export const Ref = () => {
    const [count, setCount] = useState(0);
    const ref = useRef();

    useEffect(() => {
        setTimeout(() => {
            console.log(ref.current)
            ref.current.style.backgroundColor = 'red';
        }, 2000);
    }, [])

    const handleAdd = () => {
        setCount(count + 1);
    }

    return (
        <Rows>
            <h1  className="myh1">Ref, {count}</h1>
            <Btn ref={ref} onClick={handleAdd}>Add</Btn>
        </Rows>
    )
}