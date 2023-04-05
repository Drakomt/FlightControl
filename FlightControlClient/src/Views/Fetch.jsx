import 'bootstrap/dist/css/bootstrap.css';
import { useEffect, useState } from "react"
import { Rows } from "UIKit"

export const Fetch = () => {
    const [list, setList] = useState(null);

    useEffect(() => {
        setTimeout(() => {
            fetch('http://localhost:5132/api/Flights')
                .then(resp => resp.json())
                .then(json => {
                    setList(json);
                })
        }, 2000);
    }, [])

    console.log('render')
    const renderList = () => {
        return list.map(f => {
            return <h3 key={f.id}>{f.pilot.name}</h3>
        })
    }

    return (
        <Rows>
            {!list ? (
                <h1>loading...</h1>
            ): (
                renderList()
            )}
        </Rows>
    )
}