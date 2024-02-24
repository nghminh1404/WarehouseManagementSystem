import React from 'react';
import { Navbar, Nav, NavDropdown, Form, FormControl, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
function NavbarCom() {
    return (
        <Navbar bg="body-tertiary" expand="lg">
            <Navbar.Brand href="#">WMS</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                    <Nav.Link as={Link} to="/">
                        Login
                    </Nav.Link>
                    <Nav.Link as={Link} to="/forgot-password">
                        Forgot Password
                    </Nav.Link>
                    <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                        <NavDropdown.Item as={Link} to="#">
                            Action
                        </NavDropdown.Item>
                        <NavDropdown.Item as={Link} to="#">
                            Another action
                        </NavDropdown.Item>
                        <NavDropdown.Divider />
                        <NavDropdown.Item as={Link} to="#">
                            Something else here
                        </NavDropdown.Item>
                    </NavDropdown>
                </Nav>
                <Nav className="ml-auto">
                    <Nav.Link disabled>Disabled</Nav.Link>
                </Nav>
                <Form className="d-flex">
                    <FormControl type="search" placeholder="Search" className="mr-2" aria-label="Search" />
                    <Button variant="outline-success">Search</Button>
                </Form>
            </Navbar.Collapse>
        </Navbar>
    );
}

export default NavbarCom;
