import { counterContext } from "Context/counterContext"
import { useContext } from "react"
import { Btn } from "UIKit"

export const CounterAdd = () => {
    const { handleAdd } = useContext(counterContext);

    return (
        <div>
            <Btn onClick={handleAdd}>Add</Btn>
        </div>
    )
}