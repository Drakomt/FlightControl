import { Rows, Fetch } from "UIKit";


export const FetchHookUser = () => {
    const render = (item) => {
        return <h3>{item.name}</h3>
    }

    //reder
    return (
        <Rows>
            <h2>Users list</h2>
            <Fetch url='/users/1' onRender={render} />
        </Rows>
    )
}

export const FetchHook = () => {
    const render = (list) => {
        return list.map(i => {
            return <h3 key={i.id}>{i.name}</h3>
        })
    }

    //reder
    return (
        <Rows>
            <h2>Users list</h2>
            <Fetch url='/users' onRender={render} />
        </Rows>
    )
}

export const FetchHookTodos = () => {

    const render = (list) => {
        return list.map(i => {
            return <h3 key={i.id}>{i.title}</h3>
        })
    }

    //reder
    return (
        <Rows>
            <h2>Todos list</h2>
            <Fetch url='/todos' onRender={render} />
        </Rows>
    )
}


export const FetchHookFlights = () => {

    const render = (list) => {
        /* console.log(list); */
        return (
        <div>
            <h2>Flights Details</h2>
            <table className="table table-dark table-striped">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Leg Number</th>
                        <th>Flight code</th>
                        <th>Pilot Name</th>
                    </tr>
                </thead>
                <tbody>
                    {list.map(log => (
                        <tr key={log.id}>
                            <td>{log.id}</td>
                            <td>{log.leg.number}</td>
                            <td>{log.flight.code}</td>
                            <td>{log.flight.pilot.name}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
        )
    }

    //reder
    return (
        <Rows>
            <h2>Flights</h2>
            <Fetch url='/Flights' onRender={render} />
        </Rows>
    )
}



