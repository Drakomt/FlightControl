import { useState } from "react"
import { Btn } from "UIKit";

const todos = [
    { id: 1, name: 'todo 1', completed: true },
    { id: 2, name: 'todo 2', completed: false },
    { id: 3, name: 'todo 3', completed: true },
    { id: 4, name: 'todo 4', completed: true },
    { id: 5, name: 'todo 5', completed: true },
    { id: 6, name: 'todo 6', completed: true },
    { id: 7, name: 'todo 7', completed: true },
    { id: 8, name: 'todo 8', completed: true },
    { id: 9, name: 'todo 9', completed: true }
]

export const List = () => {
    const [count, setCount] = useState(0);
    const [obj, setList] = useState({ list: todos });

    const styleCss = {
        color: 'gray'
    }

    const handleSwitch = (u) => {
        u.completed = !u.completed;
        setList({ ...obj });

    }

    const handleAdd = () => {
        setCount(count + 1);
    }

    let i = 0;

    function uuidv4() {
        return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
          (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
        );
      }
      

    return (
        <div>
            <h1>Lists, {count}</h1>
            <Btn onClick={handleAdd}>Add</Btn>
            {obj.list.map((u, index) => {
                return (
                    <h3
                        style={u.completed ? styleCss : {}}
                        key={uuidv4()}
                        onClick={() => handleSwitch(u)}
                    >
                        {u.name}
                    </h3>
                )
            })}
        </div>
    )
}