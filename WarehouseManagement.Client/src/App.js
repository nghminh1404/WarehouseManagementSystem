import Login from './views/pages/authentication/Login';
import ForgotPassword from './views/pages/authentication/ForgotPassword';
import ResetPassword from './views/pages/authentication/ResetPassword';
import { Routes, Route } from 'react-router-dom';
import NavbarCom from './views/components/NavbarCom';
function App() {
    return (
        <div className="app">
            <NavbarCom />
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/forgot-password" element={<ForgotPassword />} />
                <Route path="/reset-password" element={<ResetPassword />} />
            </Routes>
        </div>
    );
}

export default App;
