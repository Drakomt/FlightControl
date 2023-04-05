import { add, remove, setTodos, toggle } from 'State/todos';
import { Rows, Line, Icon, Between, Input, Btn } from 'UIKit';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

export const Todos = () => {
    const todos = useSelector(store => store.todos);
    const dispatch = useDispatch();
    const [value, setValue] = useState('');

    useEffect(() => {
        axios.get('https://jsonplaceholder.typicode.com/todos')
            .then(resp => {
                const list = resp.data.splice(0, 10);
                dispatch(setTodos(list))
            })
    }, [])

    const handleToggle = (item) => {
        dispatch(toggle(item))
    }

    const handleRemove = (item) => {
        dispatch(remove(item))
    }

    const handleAdd = () => {
        dispatch(add(value));
        setValue('');
    }

    const styleBox = {
        width: '300px',
        padding: 'var(--gap)'
    }

    return (
        <div style={styleBox}>
            <Rows>
                <h1>Todos list</h1>
                <Line>
                    <Input value={value} onChange={(e) => setValue(e.target.value)} />
                    <Btn onClick={handleAdd}>Add</Btn>
                </Line>
                {
                    todos.list.map(i => {
                        return (
                            <div key={i.id}>
                                <Between>
                                    <Line >
                                        <Icon i={i.completed ? 'check_box' : 'square'} onClick={() => handleToggle(i)} />
                                        <h5>{i.title}</h5>
                                    </Line>
                                    <div>
                                        <Icon i="delete" onClick={() => handleRemove(i)} />
                                    </div>
                                </Between>
                            </div>
                        )
                    })
                }
            </Rows>
        </div>
    )
}