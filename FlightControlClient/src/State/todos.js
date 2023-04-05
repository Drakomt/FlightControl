import { createSlice } from "@reduxjs/toolkit"

const initialState = {
    list: []
}

const todosReducer = createSlice({
    name: 'todos',
    initialState,
    reducers: {
        setTodos: (state, action) => {
            state.list = action.payload;
        },
        toggle: (state, action) => {
            const index = state.list.findIndex(i => i.id === action.payload.id);
            state.list[index].completed = !state.list[index].completed;
        },
        remove: (state, action) => {
            const index = state.list.findIndex(i => i.id === action.payload.id);
            state.list.splice(index, 1);
        },
        add: (state, action) => {
            state.list.push({
                id: Math.random(),
                completed: false,
                title: action.payload
            })
        }
    }
})

export const { setTodos, toggle, remove, add } = todosReducer.actions;

export default todosReducer.reducer;