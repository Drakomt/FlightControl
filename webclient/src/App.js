import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { flights: [], loading: true };
    }

    componentDidMount() {
        this.populateFlightsData();
    }

    static renderFlightsTable(flights) {
        console.log(flights)
        return (
           // <div>
           //    <h2>Flights Details</h2>
           //    <table>
           //        <thead>
           //            <tr>
           //                <th>Code</th>
           //            </tr>
           //        </thead>
           //        <tbody>
           //             {this.state.flights.map(f => (
           //                 <tr key={f.id}>
           //                     <td>{f.id}</td>
           //                     <td>{f.Code}</td>
           //                 </tr>
           //                 ))}
           //        </tbody>
           //    </table>
           //</div>

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name: </th>
                    </tr>
                </thead>
                <tbody>
                    {flights.map(flight =>
                        <tr key={flight.id}>
                            <td>{flight.Code}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderFlightsTable(this.state.flights);

        return (
            <div>
                <h1 id="tabelLabel" >Flights</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateFlightsData() {
        const response = await fetch('http://localhost:5132/api/Flights');
        const data = await response.json();
        this.setState({ flights: data, loading: false });
    }
}
