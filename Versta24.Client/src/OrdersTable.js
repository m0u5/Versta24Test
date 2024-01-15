import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Box from '@mui/material/Box';
import { useNavigate } from "react-router-dom";
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
const OrdersTable = () => {
    const [orders, setOrders] = useState([]);
    const navigate = useNavigate();

    const fetchOrders = async () => {
        const response = await axios.get('https://localhost:7018/api/Order')
        setOrders(response.data["orders"])
        console.log(response)

    };

    useEffect(() => {
        fetchOrders();
    }, []);

    const handleEvent = (
        params, // GridRowParams

    ) => {
        navigate("/Orders/" + params.row.id)
    };

    const columns = [

        {
            field: 'orderNum',
            headerName: 'Номер заказа',
            type: 'number',
            width: 150,

        },
        {
            field: 'senderCity',
            headerName: 'Город отправителя',
            width: 150,

        },
        {
            field: 'senderAddres',
            headerName: 'Адрес отправителя',

            width: 110,

        },
        {
            field: 'recipientCity',
            headerName: 'Город получателя',
            description: 'This column has a value getter and is not sortable.',

            width: 160,

        },
        {
            field: 'recipientAddres',
            headerName: 'Адрес получателя',
            description: 'This column has a value getter and is not sortable.',

            width: 160,

        },
        {
            field: 'cargoWeight',
            headerName: 'Вес',
            description: 'This column has a value getter and is not sortable.',
            type: 'number',
            width: 160,

        },
        {
            field: 'collectionDate',
            headerName: 'Дата забора груза',
            description: 'This column has a value getter and is not sortable.',
            valueGetter: (params) => {

                return new Date(params.row.collectionDate).toLocaleDateString()
            }




            ,
            width: 160,

        },
    ];
    return (
        <div style={{ display: "flex", alignItems: "center", justifyContent: "center" }}>
            <Box sx={{ height: "100%", width: '100%' }}>
                <DataGrid onRowClick={handleEvent}
                    rows={orders}
                    columns={columns}
                    initialState={{
                        pagination: {
                            paginationModel: {
                                pageSize: 10,
                            },
                        },
                    }}
                    pageSizeOptions={[10]}


                />
            </Box>
        </div>
    );

    return (
        <table>
            <thead>
                <tr>
                    <th>Номер заказа</th>
                    <th>Город отправителя</th>
                    <th>Адрес отправителя</th>
                    <th>Город получателя</th>
                    <th>Адрес получателя</th>
                    <th>Вес груза</th>
                    <th>Дата забора груза</th>
                </tr>
            </thead>
            <tbody>
                {orders.map(order =>
                    <tr key={order.id}>
                        <td>{order.orderNum}</td>
                        <td>{order.senderCity}</td>
                        <td>{order.senderAddress}</td>
                        <td>{order.recipientCity}</td>
                        <td>{order.recipientAddress}</td>
                        <td>{order.cargoWeight}</td>
                        <td>{order.collectionDate}</td>
                    </tr>
                )}


            </tbody>
        </table>
    );
};

export default OrdersTable;
