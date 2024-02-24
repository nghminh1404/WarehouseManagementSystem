import logo from '../../../assets/images/logo.png';
import shape from '../../../assets/images/Shape.png';
import { Form, Button } from 'react-bootstrap';

const ResetPassword = () => {
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
                                    <h2 className="fw-bold mb-0">Đặt lại mật khẩu</h2>
                                </div>

                                <h5 className="fw-normal mb-3 pb-3">Vui lòng nhập mật khẩu mà bạn muốn đặt</h5>

                                <Form.Group className="mb-4">
                                    <Form.Label>Mật khẩu</Form.Label>
                                    <div className="input-group">
                                        <Form.Control
                                            type="password"
                                            id="password1"
                                            className="form-control form-control-lg"
                                        />
                                    </div>
                                </Form.Group>

                                <Form.Group className="mb-4">
                                    <Form.Label>Nhập lại mật khẩu</Form.Label>
                                    <Form.Control
                                        type="password"
                                        id="password2"
                                        className="form-control form-control-lg"
                                    />
                                    <p className="warning">Nhập lại mật khẩu không đúng!</p>
                                </Form.Group>

                                <div className="pt-1 mb-4">
                                    <Button className="btn btn-lg btn-block w-100 color-primary" type="button">
                                        Đặt lại mật khẩu
                                    </Button>
                                </div>
                            </Form>
                        </div>
                    </div>
                    <div className="col-lg-2"></div>
                </div>
            </div>
        </section>
    );
};

export default ResetPassword;
