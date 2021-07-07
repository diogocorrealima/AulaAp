import React from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import {
    decrement,
    increment,
    incrementAsync,
    selectOrder,
} from './orderSlice';

import { DataGrid, GridRowsProp, GridColDef } from '@material-ui/data-grid';
import OrderAPI from './orderAPI';


export default function OrderList() {
    const orderAPI = new OrderAPI();
    var teste = orderAPI.getOrderByOrderCode("1");
    const dispatch = useAppDispatch();
    const columns: GridColDef[] = [
        { field: 'col1', headerName: '#', width: 150 },
    ];
    const orders = useAppSelector(selectOrder);
    const rows = orders.map(order => {
        return { id: order.id, col1: order.products.length };
    }
    );
    return (
        <div style={{ height: 300, width: '100%' }}>
            <DataGrid rows={rows} columns={columns} />
        </div>
    )
}
