import logo from '../../../assets/images/logo.png';
import shape from '../../../assets/images/Shape.png';

const ResetPassword = () => {
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
                                    <span className="h1 fw-bold mb-0">Đặt lại mật khẩu</span>
                                </div>

                                <h5 className="fw-normal mb-3 pb-3">Vui lòng nhập mật khẩu mà bạn muốn đặt</h5>

                                <div className="form-outline mb-4">
                                    <label className="form-label" htmlFor="form2Example17">
                                        Mật khẩu
                                    </label>
                                    <div className="input-group">
                                        <input
                                            type="password"
                                            id="password1"
                                            className="form-control form-control-lg"
                                        />
                                    </div>
                                </div>

                                <div className="form-outline mb-4">
                                    <label className="form-label" htmlFor="form2Example27">
                                        Nhập lại mật khẩu
                                    </label>
                                    <input type="password" id="password2" className="form-control form-control-lg" />
                                    <p className="warning">Nhập lại mật khẩu không đúng!</p>
                                </div>

                                <div className="pt-1 mb-4">
                                    <button className="btn  btn-lg btn-block w-100 color-primary" type="button">
                                        Đặt lại mật khẩu
                                    </button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default ResetPassword;
