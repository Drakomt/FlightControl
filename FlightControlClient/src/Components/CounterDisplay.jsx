import { counterContext } from "Context/counterContext"
import { useContext } from "react"
import { Rows } from "UIKit";

export const CounterDisplay = () => {
    const {count} = useContext(counterContext);
   

    return (
        <Rows>
            <h4>count {count}</h4>
        </Rows>
    )
}