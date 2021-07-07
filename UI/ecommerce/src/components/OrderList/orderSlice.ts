import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { stat } from 'fs';
import { RootState, AppThunk } from '../../app/store';

export interface IProduct {
  id: number;
  quantity: number;
  value: number;
}

export interface IOrderState {
  id: number;
  products: IProduct[]
}

const initialState: IOrderState[] = [
  {
    id: 1,
    products: [],
  },
];

// The function below is called a thunk and allows us to perform async logic. It
// can be dispatched like a regular action: `dispatch(incrementAsync(10))`. This
// will call the thunk with the `dispatch` function as the first argument. Async
// code can then be executed and other actions can be dispatched. Thunks are
// typically used to make async requests.
export const incrementAsync = createAsyncThunk(
  'orders/add',
  async (order: IOrderState) => {
    const response = {
      data: [
        {
          id: 1,
          products: [],
        },
      ]
    }
    // The value we return becomes the `fulfilled` action payload
    return response.data;
  }
);

export const orderSlice = createSlice({
  name: 'order',
  initialState,
  // The `reducers` field lets us define reducers and generate associated actions
  reducers: {
    increment: (state) => {
      // Redux Toolkit allows us to write "mutating" logic in reducers. It
      // doesn't actually mutate the state because it uses the Immer library,
      // which detects changes to a "draft state" and produces a brand new
      // immutable state based off those changes
      state.push(
        {
          id: 2,
          products: [],
        }
      );
    },
    decrement: (state) => {
      state.slice(0)
    },

  },
});

export const { increment, decrement } = orderSlice.actions;

export const selectOrder = (state: RootState) => state.orderList;
export default orderSlice.reducer;


