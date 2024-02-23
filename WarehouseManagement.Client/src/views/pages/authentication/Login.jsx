import logo from '../../../assets/images/logo.png';
import shape from '../../../assets/images/Shape.png';

const Login = () => {
    return (
        <section className="h-100">
            <div className="container-fluid">
                <div className="row" style={{ padding: '100px', paddingLeft: '300px', paddingRight: '300px' }}>
                    <div className="col-sm-6 px-0 d-lg-flex align-items-center justify-content-center custom-rounded">
                        <div
                            className="w-100 d-flex flex-column align-items-center justify-content-center custom-rounded"
                            style={{ backgroundColor: '#f8f7fa', height: '80vh', position: 'relative' }}
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
                    <div className="col-sm-6 d-flex align-items-center">
                        <div className="card-body p-4 p-lg-5 text-black">
                            <form>
                                <div className="d-flex align-items-center mb-3 pb-1">
                                    <span className="h1 fw-bold mb-0">Chào mừng tới với WMS!</span>
                                </div>

                                <h5 className="fw-normal mb-3 pb-3">
                                    Vui lòng đăng nhập tài khoản để tiếp tục sử dụng dịch vụ
                                </h5>

                                <div className="form-outline mb-4">
                                    <label className="form-label" htmlFor="form2Example17">
                                        Tên đăng nhập
                                    </label>
                                    <input type="email" id="form2Example17" className="form-control form-control-lg" />
                                </div>

                                <div className="form-outline mb-4">
                                    <label className="form-label" htmlFor="form2Example27">
                                        Mật khẩu
                                    </label>
                                    <input
                                        type="password"
                                        id="form2Example27"
                                        className="form-control form-control-lg"
                                    />
                                    <a className="small text-muted" href="#!">
                                        Quên mật khẩu?
                                    </a>
                                </div>

                                <div className="pt-1 mb-4">
                                    <button className="btn  btn-lg btn-block w-100 color-primary" type="button">
                                        Đăng nhập
                                    </button>
                                </div>
                                <p className="warning d-lg-flex align-items-center justify-content-center">
                                    Sai tên tài khoản hoặc mật khẩu!
                                </p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default Login;
