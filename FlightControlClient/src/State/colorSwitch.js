import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    isRed: true
}

export const colorSwitchSlice = createSlice({
    name: 'colorSwitch',
    initialState,
    reducers: {
        toggle: (state) => {
            state.isRed = !state.isRed;
        }
    }
})

export const { toggle } = colorSwitchSlice.actions;

export default colorSwitchSlice.reducer;