import './App.css';
import { Btn, Icon, GridMain, Line, Rows, Dropdown, Inner, Between } from 'UIKit';
import { Link, NavLink, Route, Routes } from 'react-router-dom';
import { Home } from 'Views/Home';
import { About } from 'Views/About';
import { States } from 'Views/States';
import { List } from 'Views/List';
import { LifeCycle } from 'Views/LifeCycle';
import { Fetch } from 'Views/Fetch';
import { Ref } from 'Views/Ref';
import { DropdownView } from 'Views/DropdownView';
import { CustomHooks } from 'Views/CustomHooks';
import { Context } from 'Views/Context';
import { useContext } from 'react';
import { counterContext } from 'Context/counterContext';
import { colorSwitchContext } from 'Context/colorSwitchContext';
import { themeContext } from 'Context/themeContext';
import { useSelector } from 'react-redux';
import { Todos } from 'Views/Todos';

export const App = () => {
    const counter = useSelector(store => store.counter);
    const todos = useSelector(store => store.todos);

    const { count } = useContext(counterContext);
    const { color } = useContext(colorSwitchContext);
    const theme = useContext(themeContext);

    return (
        <div className='App' theme={theme.selected}>
            <GridMain>
                <div>
                    <Inner>
                        <Between>
                            <Line>
                                <NavLink to='/about'>About</NavLink>
                                <NavLink to='/home'>Home</NavLink>
                                <NavLink to='/states'>States</NavLink>
                                <NavLink to='/list'>Lists</NavLink>
                                <NavLink to='/cycle'>Cycle</NavLink>
                                <NavLink to='/fetch'>Fetch</NavLink>
                                <NavLink to='/ref'>Ref</NavLink>
                                <NavLink to='/dropdown'>Dropdown</NavLink>
                                <NavLink to='/hooks'>Hooks</NavLink>
                                <NavLink to='/context'>Context</NavLink>
                                <NavLink to='/todos'>Todos</NavLink>
                            </Line>
                            <div>
                                <Dropdown {...theme} />
                            </div>
                        </Between>
                    </Inner>
                </div>
                <div>
                    <Routes>
                        <Route path='/home' element={<Home />} />
                        <Route path='/about' element={<About />} />
                        <Route path='/states' element={<States />} />
                        <Route path='/list' element={<List />} />
                        <Route path='/cycle' element={<LifeCycle />} />
                        <Route path='/fetch' element={<Fetch />} />
                        <Route path='/ref' element={(
                            <Rows>
                                <Ref />
                                <Ref />
                            </Rows>
                        )} />
                        <Route path='/dropdown' element={<DropdownView />} />
                        <Route path='/hooks' element={<CustomHooks />} />
                        <Route path='/context' element={<Context />} />
                        <Route path='/todos' element={<Todos />} />
                    </Routes>


                </div>
                <div className='alter'>
                    <Inner>
                        <Line>
                            <h5>footer</h5>
                            <h5 style={{ color }}>Count: {count}</h5>
                            <h5>Redux: {counter.count}</h5>
                            <h5>Todos: {todos.list.length}</h5>
                        </Line>
                    </Inner>
                </div>
            </GridMain>
        </div>
    )
}