import { useState } from "react"
import { Dropdown, Rows } from "UIKit"

const list = [
    { id: 1, name: 'mosh'},
    { id: 2, name: 'david'},
    { id: 3, name: 'ruth'}
]

export const DropdownView = () => {
    const [selected, setSelected] = useState(null);

    return (
        <Rows>
            <h1>Dropdown View</h1>
            <Dropdown list={list} selected={selected} onChange={setSelected}/>
        </Rows>
    )
}