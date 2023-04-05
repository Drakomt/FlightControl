import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    count: 10
}

export const counterSlice = createSlice({
    name: 'counter',
    initialState,
    reducers: {
        add: (state) => {
            state.count += 1;
        },
        reduce: (state) => {
            state.count -= 1;
        },
        amount: (state, action) => {
            state.count += action.payload;
        }
    }
})

export const { add, reduce, amount } = counterSlice.actions;


export default counterSlice.reducer;