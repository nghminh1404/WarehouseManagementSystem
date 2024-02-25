import logo from '../../../assets/images/logo.png';
import shape from '../../../assets/images/Shape.png';
import { Form, Button } from 'react-bootstrap';

const Login = () => {
    return (
        <section className="h-100">
            <div className="container-fluid">
                <div className="row" style={{ padding: '50px' }}>
                    <div className="col-lg-2"></div>
                    <div className="col-lg-4 d-flex align-items-center justify-content-center">
                        <div
                            className="w-100 d-flex flex-column align-items-center justify-content-center custom-rounded"
                            style={{ backgroundColor: '#f8f7fa', minHeight: '80vh', position: 'relative' }}
                        >
                            <img
                                className="mb-5"
                                style={{ width: '300px' }}
                                src={logo}
                                alt="WAREHOUSE MANAGEMENT SYSTEM"
                            />
                            <img
                                className="mb-5"
                                style={{ width: '400px', position: 'absolute', bottom: '210px' }}
                                src={shape}
                                alt="WAREHOUSE MANAGEMENT SYSTEM"
                            />
                            <h1 className="text-center" style={{ fontWeight: '650' }}>
                                WAREHOUSE
                                <br />
                                MANAGEMENT SYSTEM
                            </h1>
                        </div>
                    </div>
                    <div className="col-lg-4 d-flex align-items-center justify-content-center">
                        <div className="card-body p-4 p-lg-5 text-black">
                            <Form>
                                <div className="d-flex align-items-center mb-3 pb-1">
                                    <h2 className="fw-bold mb-0">Chào mừng tới với WMS!</h2>
                                </div>

                                <h5 className="fw-normal mb-3 pb-3">
                                    Vui lòng đăng nhập tài khoản để tiếp tục sử dụng dịch vụ
                                </h5>

                                <Form.Group className="mb-4">
                                    <Form.Label>Tên đăng nhập</Form.Label>
                                    <div className="input-group">
                                        <Form.Control type="email" required placeholder="Tên đăng nhập" />
                                    </div>
                                </Form.Group>

                                <Form.Group className="mb-4">
                                    <Form.Label>Mật khẩu</Form.Label>
                                    <div className="input-group">
                                        <Form.Control type="password" required placeholder="Mật khẩu" />
                                    </div>
                                    <a className="small text-muted" href="#!">
                                        Quên mật khẩu?
                                    </a>
                                </Form.Group>

                                <div className="pt-1 mb-4">
                                    <Button className="btn btn-lg btn-block w-100 color-primary" type="button">
                                        Đăng nhập
                                    </Button>
                                </div>

                                <p className="warning d-flex align-items-center justify-content-center">
                                    Sai tên tài khoản hoặc mật khẩu!
                                </p>
                            </Form>
                        </div>
                    </div>
                    <div className="col-lg-2"></div>
                </div>
            </div>
        </section>
    );
};

export default Login;
