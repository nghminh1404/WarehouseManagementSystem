import Login from './views/pages/authentication/Login';
import ForgotPassword from './views/pages/authentication/ForgotPassword';
import ResetPassword from './views/pages/authentication/ResetPassword';
import { Routes, Route } from 'react-router-dom';
import NavbarCom from './views/components/NavbarCom';
import ProductList from './views/product/ProductList'
import Sidebar from './views/components/Sidebar';
function App() {
    return (
        <div className="app">
            <Sidebar/>
            <NavbarCom />
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/forgot-password" element={<ForgotPassword />} />
                <Route path="/reset-password" element={<ResetPassword />} />
                <Route path="/ProductList" element={<ProductList />} />
            </Routes>
        </div>
    );
}

export default App;
