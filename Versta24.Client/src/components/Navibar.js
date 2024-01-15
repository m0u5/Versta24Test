import React from "react";
import { Navbar, Nav, Button } from "react-bootstrap";
import { Link } from "react-router-dom";

export function NaviBar() {
    return (
        <>
            <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link><Link to="/">Создать заказ</Link></Nav.Link>
                        <Nav.Link><Link to="/Orders">Таблица заказов</Link></Nav.Link>
                    </Nav>

                </Navbar.Collapse>
            </Navbar>
        </>
    )

}