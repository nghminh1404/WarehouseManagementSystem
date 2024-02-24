import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import logo from '../../assets/images/logo.png';
import { Link } from 'react-router-dom';
function NavbarCom() {
    return (
        <Navbar bg="body-tertiary" expand="lg">
            <Container>
                <Navbar.Toggle aria-controls="navbarSupportedContent" />
                <Navbar.Collapse id="navbarSupportedContent">
                    <Navbar.Brand href="#">
                        <img src={logo} height="30" alt="MDB Logo" loading="lazy" />
                    </Navbar.Brand>
                    <Nav className="me-auto">
                        <Nav.Link as={Link} to="/">
                            Login
                        </Nav.Link>
                        <Nav.Link as={Link} to="/forgot-password">
                            Forgot Password
                        </Nav.Link>
                        <Nav.Link as={Link} to="/reset-password">
                            Reset Password
                        </Nav.Link>
                    </Nav>
                    <Nav className="d-flex align-items-center">
                        <Nav.Link to="#">
                            <i className="fas fa-shopping-cart"></i>
                        </Nav.Link>
                        <NavDropdown
                            title={
                                <span>
                                    <i className="fas fa-bell"></i>
                                    <span className="badge rounded-pill badge-notification bg-danger">1</span>
                                </span>
                            }
                            id="navbarDropdownMenuLink"
                        >
                            <NavDropdown.Item href="#">Some news</NavDropdown.Item>
                            <NavDropdown.Item href="#">Another news</NavDropdown.Item>
                            <NavDropdown.Item href="#">Something else here</NavDropdown.Item>
                        </NavDropdown>
                        <NavDropdown
                            title={
                                <img
                                    src="https://mdbcdn.b-cdn.net/img/new/avatars/2.webp"
                                    className="rounded-circle"
                                    height="25"
                                    alt="Black and White Portrait of a Man"
                                    loading="lazy"
                                />
                            }
                            id="navbarDropdownMenuAvatar"
                        >
                            <NavDropdown.Item href="#">My profile</NavDropdown.Item>
                            <NavDropdown.Item href="#">Settings</NavDropdown.Item>
                            <NavDropdown.Item href="#">Logout</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavbarCom;
