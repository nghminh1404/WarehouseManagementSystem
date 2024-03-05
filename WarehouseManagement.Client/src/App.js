import Login from './views/pages/authentication/Login';
import ForgotPassword from './views/pages/authentication/ForgotPassword';
import ResetPassword from './views/pages/authentication/ResetPassword';
import { Routes, Route } from 'react-router-dom';
import NavbarCom from './views/components/NavbarCom';
import ProductList from './views/product/ProductList';
import AddProduct from './views/product/AddProduct';
import EditProduct from './views/product/EditProduct';
import DeleteProduct from './views/product/DeleteProduct';
import SupplierList from './views/suppliers/SuppliersList';
import Sidebar from './views/components/Sidebar';
import { Container, Row, Col } from 'react-bootstrap';
import { ToastContainer, toast } from 'react-toastify';
function App() {
    return (
        <>
            <div className="app">
                <Routes>
                    <Route
                        path="/"
                        element={
                            <Container fluid>
                                <NavbarCom />
                                <Login />
                            </Container>
                        }
                    />
                    <Route
                        path="/forgot-password"
                        element={
                            <Container fluid>
                                <NavbarCom />
                                <ForgotPassword />
                            </Container>
                        }
                    />
                    <Route
                        path="/reset-password"
                        element={
                            <Container fluid>
                                <NavbarCom />
                                <ResetPassword />
                            </Container>
                        }
                    />
                    <Route
                        path="/ProductList"
                        element={
                            <Container fluid>
                                <Row className="flex-nowrap">
                                    <Sidebar />

                                    <Col className="py-3 background-primary">
                                        <NavbarCom />
                                        <ProductList />
                                    </Col>
                                </Row>
                            </Container>
                        }
                    />
                    <Route
                        path="/AddProduct"
                        element={
                            <Container fluid>
                                <Row className="flex-nowrap">
                                    <Sidebar />

                                    <Col className="py-3 background-primary">
                                        <NavbarCom />
                                        <AddProduct />
                                    </Col>
                                </Row>
                            </Container>
                        }
                    />

                    <Route
                        path="/EditProduct"
                        element={
                            <Container fluid>
                                <Row className="flex-nowrap">
                                    <Sidebar />

                                    <Col className="py-3 background-primary">
                                        <NavbarCom />
                                        <EditProduct />
                                    </Col>
                                </Row>
                            </Container>
                        }
                    />


                    <Route
                        path="/DeleteProduct"
                        element={
                            <Container fluid>
                                <Row className="flex-nowrap">
                                    <Sidebar />

                                    <Col className="py-3 background-primary">
                                        <NavbarCom />
                                        <DeleteProduct />
                                    </Col>
                                </Row>
                            </Container>
                        }
                    />

                    <Route
                        path="/nha-cung-cap"
                        element={
                            <Container fluid>
                                <Row className="flex-nowrap">
                                    <Sidebar />

                                    <Col className="py-3 background-primary">
                                        <NavbarCom />
                                        <SupplierList />
                                    </Col>
                                </Row>
                            </Container>
                        }
                    />
                </Routes>



            </div>

            <ToastContainer
                position="top-right"
                autoClose={3000}
                hideProgressBar={false}
                newestOnTop={false}
                closeOnClick
                rtl={false}
                pauseOnFocusLoss
                draggable
                pauseOnHover
                theme="light"
            />
        </>

    );
}

export default App;
