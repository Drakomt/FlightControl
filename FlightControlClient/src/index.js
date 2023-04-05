import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';

import { App } from './App';

import { BrowserRouter } from 'react-router-dom';
import { CounterProvider } from 'Context/counterContext';
import { ColorSwitchProvider } from 'Context/colorSwitchContext';
import { ThemeProvider } from 'Context/themeContext';
import { ReduxProvider } from 'State/store';



const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <ReduxProvider>
        <ThemeProvider>
            <ColorSwitchProvider>
                <CounterProvider>
                    <BrowserRouter>
                        <App />
                    </BrowserRouter>
                </CounterProvider>
            </ColorSwitchProvider>
        </ThemeProvider>
    </ReduxProvider>
);


