import React from "react";
import axios from 'axios';
import { useState, useEffect } from 'react';
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import { useParams } from 'react-router-dom'
function GetOrder() {
    const { id } = useParams()
    const [order, setOrder] = useState({});

    const GetOrderById = async () => {

        const response = await axios.get('https://localhost:7018/api/Order/' + id);
        setOrder(response.data)
        console.log(response.data)

    };
    useEffect(() => {
        GetOrderById();
    }, {});

    return (
        <div className="container">
            <div className="col-md-4 p-2 offset-4 border rounded-4">
                <ListGroup as="ul" >
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Номер заказа</div>
                            {order.orderNum}
                        </div>

                    </ListGroup.Item>
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Город получателя</div>
                            {order.recipientCity}
                        </div>

                    </ListGroup.Item>
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Адрес получателя</div>
                            {order.recipientAddres}
                        </div>

                    </ListGroup.Item>
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Город отправителя</div>
                            {order.senderCity}
                        </div>

                    </ListGroup.Item>
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Адрес отправителя</div>
                            {order.senderAddres}
                        </div>

                    </ListGroup.Item>
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Вес</div>
                            {order.cargoWeight}
                        </div>

                    </ListGroup.Item>
                    <ListGroup.Item
                        as="li"
                        className="d-flex justify-content-between align-items-start"
                    >
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">Дата выдачи</div>
                            {new Date(order.collectionDate).toLocaleDateString()}
                        </div>

                    </ListGroup.Item>

                </ListGroup>
            </div>
        </div>
    );
}

export default GetOrder;