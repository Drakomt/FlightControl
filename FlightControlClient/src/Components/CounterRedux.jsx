import { add, amount, reduce } from "State/counter";
import { Btn, Line, Rows } from "UIKit"
import { useDispatch, useSelector } from "react-redux"

export const CounterRedux = () => {
    const counter = useSelector((store) => store.counter);
    const dispatch = useDispatch();

    const handleAdd = () => {
        dispatch(add())
    }

    const handleAddFive = () => {
        dispatch(amount(5))
    }

    const handleReduce = () => {
        dispatch(reduce())
    }


    return (
        <Rows>
            <h3>Count, {counter.count}</h3>
            <Line>
                <Btn onClick={handleAdd}>Add</Btn>
                <Btn onClick={handleReduce}>Reduce</Btn>
                <Btn onClick={handleAddFive}>Add 5</Btn>
            </Line>
        </Rows>
    )
}