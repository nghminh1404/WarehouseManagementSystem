const Login = () => {
    return (
        <section className="h-100">
            <div className="container-fluid">
                <div className="row p-5">
                    <div className="col-sm-6 px-0 d-none d-sm-block">
                        <div className="w-100 h-100  d-flex align-items-center justify-content-center" style={{ backgroundColor: '#f0f0f0' }}>
                            <h1>WAREHOUSE MANAGEMENT SYSTEM</h1>
                        </div>
                    </div>
                    <div className="col-sm-6 d-flex align-items-center">
                        <div className="card-body p-4 p-lg-5 text-black">
                            <form>
                                <div className="d-flex align-items-center mb-3 pb-1">
                                    <span className="h1 fw-bold mb-0">Chào mừng tới với WMS!</span>
                                </div>

                                <h5 className="fw-normal mb-3 pb-3">Vui lòng đăng nhập tài khoản để tiếp túc sử dụng dịch vụ</h5>

                                <div className="form-outline mb-4">
                                    <label className="form-label" htmlFor="form2Example17">Tên đăng nhập</label>
                                    <input type="email" id="form2Example17" className="form-control form-control-lg" />
                                </div>

                                <div className="form-outline mb-4">
                                    <label className="form-label" htmlFor="form2Example27">Mật khẩu</label>

                                    <input type="password" id="form2Example27" className="form-control form-control-lg" />
                                </div>

                                <div className="pt-1 mb-4">
                                    <button className="btn btn-success btn-lg btn-block w-100" type="button">Đăng nhập</button>
                                </div>

                                <a className="small text-muted" href="#!">Lấy lại mật khẩu ?</a>
                            </form>
                        </div>
                    </div>

                </div>
            </div>
        </section>
    )
}


export default Login;