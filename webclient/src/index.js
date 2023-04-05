import React from 'react';
import ReactDOM from 'react-dom';
//import ReactDOM from 'react-dom/client';
//import './index.css';
//import reportWebVitals from './reportWebVitals';
//import FlightsComponent from './App';

//const root = ReactDOM.createRoot(document.getElementById('root'));
//root.render(
//  <React.StrictMode>
//    <App />
//  </React.StrictMode>
//);



class FlightsComponent extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            flights: []
        };
    }

    componentDidMount() {
        fetch("http://localhost:5132/api/Flights").then(res => res.json()).then(
            result => {
                this.setState({ flights: result });
            }
        )
    } 

    render() {
        console.log(this.state.flights);
        return (
            <div>
                <h2>Flights Details</h2>
                <table>
                    <thead>
                        <tr>
                            <th>Code</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.flights.map(f => (
                            <tr key={f.id}>
                                <td>{f.Pilot?.Name}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

}


const element = <FlightsComponent></FlightsComponent>
ReactDOM.render(element, document.getElementById("root"));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals


/*reportWebVitals();*/
