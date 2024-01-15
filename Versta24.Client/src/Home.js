import React from "react";
import axios from 'axios';
import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Alert from 'react-bootstrap/Alert';

function Home() {

    const [senderCity, setSenderCity] = useState('');
    const [senderAddres, setSenderAddres] = useState('');
    const [recipientCity, setRecipientCity] = useState('');
    const [recipientAddres, setRecipientAddres] = useState('');
    const [cargoWeight, setCargoWeight] = useState('');
    const [collectionDate, setCollectionDate] = useState('');
    const [validated, setValidated] = useState(false)
    const [success, setSuccess] = useState(false)
    async function handleSubmit(event) {
        event.preventDefault();
        const form = event.currentTarget;
        if (form.checkValidity() === false) {

            event.stopPropagation();
        } else {
            try {
                let response = await axios.post('https://localhost:7018/api/Order',
                    {
                        "senderCity": senderCity,
                        "senderAddres": senderAddres,
                        "recipientCity": recipientCity,
                        "recipientAddres": recipientAddres,
                        "cargoWeight": cargoWeight,
                        "collectionDate": collectionDate
                    },
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }

                );
                if (response.status == 201) {
                    setSuccess(true);
                }
                else {
                    setSuccess(false)
                }


            } catch (error) {

                setSuccess(false)
                console.log(error);
                console.log(collectionDate);

            }
        }
        setValidated(true);
    }

    return (
        <>
            <div className="container">

                <div className="col-md-4 p-2 offset-4 border rounded-4">
                    <Form noValidate validated={validated} onSubmit={handleSubmit}>
                        <Form.Group className="mb-3" >
                            <Form.Label>Город отправителя</Form.Label>
                            <Form.Control required type="text" value={senderCity} onChange={(event) => setSenderCity(event.target.value)} />
                            <Form.Control.Feedback type="invalid">Пожалуйста, заполните это поле.</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>Адрес отправителя</Form.Label>
                            <Form.Control required type="text" value={senderAddres} onChange={(event) => setSenderAddres(event.target.value)} />
                            <Form.Control.Feedback type="invalid">Пожалуйста, заполните это поле.</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>Город получателя</Form.Label>
                            <Form.Control required type="text" value={recipientCity} onChange={(event) => setRecipientCity(event.target.value)} />
                            <Form.Control.Feedback type="invalid">Пожалуйста, заполните это поле.</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>Адрес получателя</Form.Label>
                            <Form.Control required type="text" value={recipientAddres} onChange={(event) => setRecipientAddres(event.target.value)} />
                            <Form.Control.Feedback type="invalid">Пожалуйста, заполните это поле.</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>Вес груза</Form.Label>
                            <Form.Control required min="0.001" type="number" step=".001" value={cargoWeight} onChange={(event) => setCargoWeight(event.target.value)} />
                            <Form.Control.Feedback type="invalid">Пожалуйста, заполните это поле корректным значением.</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="mb-3"  >
                            <Form.Label>Дата</Form.Label>
                            <Form.Control required
                                type="date" value={collectionDate}
                                onChange={(event) => {
                                    const selectedDate = new Date(event.target.value);
                                    const currentDate = new Date();
                                    if (selectedDate < currentDate) {
                                        alert('Пожалуйста, выберите дату позже текущей.');
                                        // либо можно установить ошибку напрямую
                                        // setErrors({ collectionDate: 'Пожалуйста, выберите дату позже текущей.' });
                                    } else {
                                        setCollectionDate(event.target.value);
                                    }
                                }} />
                            <Form.Control.Feedback type="invalid">Пожалуйста, выберите дату позже текущей.</Form.Control.Feedback>
                        </Form.Group>

                        <Button variant="primary" type="submit">
                            Submit
                        </Button>
                    </Form>


                </div>

            </div>
            <div style={{ position: "absolute", right: 300, top: 100, minWidth: 200 }}>
                <Alert show={success} variant="success">
                    <Alert.Heading>Успешно</Alert.Heading>
                    <p>
                        Заказ добавлен
                    </p>
                    <hr />
                    <div className="d-flex justify-content-end">
                        <Button onClick={() => setSuccess(false)} variant="outline-success">
                            закрыть
                        </Button>
                    </div>
                </Alert>
            </div>

        </>
    );
}

export default Home;
