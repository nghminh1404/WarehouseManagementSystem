import React, { useEffect, useState } from 'react';
import { Table, DropdownButton, DropdownMenu } from 'react-bootstrap';
import { fetchGoodsWithFilter } from '~/services/GoodServices';
import Dropdown from 'react-bootstrap/Dropdown';
import { Form } from 'react-bootstrap';
import { fetchAllCategories } from '~/services/CategoryServices';
import { fetchAllSuppliers } from '~/services/SupplierServices';
import { CustomToggle, CustomMenu } from '../components/others/Dropdown';

function MyTable() {
    const [listGoods, setListGoods] = useState({});

    const [selectedCategory, setSelectedCategory] = useState(null);
    const [selectedSupplier, setSelectedSupplier] = useState(null);
    const [totalCategories, setTotalCategories] = useState([]);
    const [totalSuppliers, setTotalSuppliers] = useState([]);

    useEffect(() => {
        getGoods(1);
        getAllCategories();
        getAllSuppliers();
    }, [])

    const getGoods = async (page) => {
        let res = await fetchGoodsWithFilter(1);
        setListGoods(res.data);
    }

    const getAllCategories = async () => {
        let res = await fetchAllCategories();
        setTotalCategories(res);
    }

    const getAllSuppliers = async () => {
        let res = await fetchAllSuppliers();
        setTotalSuppliers(res);
    }

    const handleCategoryClick = (eventKey, event) => {
        setSelectedCategory(eventKey);
        console.log(event);
    }

    const handleSupplierClick = (eventKey, event) => {
        setSelectedSupplier(x => eventKey);
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-sm-12">
                    <h5 style={{ color: '#a5a2ad' }}>Trang chủ/Quản lý hàng hóa</h5>
                    <div className="row no-gutters my-3 ">
                        <div className="col">
                            <DropdownButton className="ButtonCSSDropdown" title={<span><i className="fa-duotone fa-warehouse"></i> Kho</span>} variant="success">
                                <Dropdown.Item href="#">Hà Nội</Dropdown.Item>
                                <Dropdown.Item href="#">Hải Phòng</Dropdown.Item>
                            </DropdownButton>
                        </div>

                        <div className="col">

                        </div>
                        <div className="col">
                            <div className="input-group">
                                <input
                                    className="form-control border-secondary inputCSS"
                                    type="search"
                                    placeholder='Tìm kiếm...'
                                    id="example-search-input4"
                                    readOnly={false}
                                />
                                <div className="input-group-append">
                                    <button
                                        className="btn btn-outline-secondary border-left-0 rounded-0 rounded-right"
                                        type="button"
                                    >
                                        <i className="fa-solid fa-magnifying-glass"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div className="col-auto">
                            <a href="/AddProduct" className='ButtonCSSDropdown'>
                                <button
                                    className="btn btn-success border-left-0 rounded ButtonCSS"
                                    type="button"
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;Thêm hàng hóa
                                </button>
                            </a>
                        </div>
                    </div>

                    <div className=" table-responsive" style={{ minHeight: '300px', overflowX: 'auto' }}>
                        <Table className="table text-center table-border table-hover  border-primary table-sm " style={{ position: 'relative' }}>

                            <thead>
                                <tr>
                                    <th className="align-middle text-nowrap">STT</th>
                                    <th className="align-middle text-nowrap">Mã SP</th>
                                    <th className="align-middle textColor text-nowrap">TÊN SẢN PHẨM</th>
                                    <th className="align-middle text-nowrap">Hình ảnh</th>
                                    <th className="align-middle  text-nowrap" >
                                        {/* <DropdownButton className="DropdownButtonCSS" title={selectedSupplier !== null ? selectedSupplier : "Nhà cung cấp"} style={{ maxHeight: '200px', overflowY: 'auto' }} variant="success">
                                            {totalSuppliers && totalSuppliers.length > 0 && totalSuppliers.map((c, index) => (
                                                <Dropdown.Item key={`supplier ${index}`} eventKey={c.supplierName} onClick={(e) => handleSupplierClick(c.supplierName, e)}>{c.supplierName}</Dropdown.Item>
                                            ))}
                                        </DropdownButton> */}

                                        <Dropdown>
                                            <Dropdown.Toggle className="DropdownButtonCSS" style={{ backgroundColor: '#24cbc7', border: 'none' }}>
                                                {selectedSupplier !== null ? selectedSupplier : "Nhà cung cấp"}
                                            </Dropdown.Toggle>

                                            <Dropdown.Menu style={{ maxHeight: '200px', overflowY: 'auto' }}>
                                                {totalSuppliers && totalSuppliers.length > 0 && totalSuppliers.map((c, index) => (
                                                    <Dropdown.Item key={`supplier ${index}`} eventKey={c.supplierName} onClick={(e) => handleSupplierClick(c.supplierName, e)}>
                                                        {c.supplierName}
                                                    </Dropdown.Item>
                                                ))}
                                            </Dropdown.Menu>
                                        </Dropdown>




                                    </th>
                                    <th className="align-middle  text-nowrap">
                                        <DropdownButton className="DropdownButtonCSS" title={selectedCategory !== null ? selectedCategory : "Danh mục"} variant="success">
                                            {totalCategories && totalCategories.length > 0 && totalCategories.map((c, index) => (
                                                <Dropdown.Item key={`category ${index}`} eventKey={c.categoryName} onClick={(e) => handleCategoryClick(c.categoryName, e)}>{c.categoryName}</Dropdown.Item>
                                            ))}
                                        </DropdownButton>


                                    </th>

                                    <th className="align-middle text-nowrap" style={{ overflow: 'visible' }}>
                                        <Dropdown style={{ position: 'relative' }}>
                                            <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                                                <span style={{ color: 'white' }}>{selectedSupplier !== null ? selectedSupplier : "Nhà cung cấp"}</span>
                                            </Dropdown.Toggle>

                                            <Dropdown.Menu as={CustomMenu} style={{ position: 'absolute', zIndex: '9999' }}>
                                                {totalSuppliers && totalSuppliers.length > 0 && totalSuppliers.map((c, index) => (
                                                    <Dropdown.Item key={`supplier ${index}`} eventKey={c.supplierName} onClick={(e) => handleSupplierClick(c.supplierName, e)}>
                                                        {c.supplierName}
                                                    </Dropdown.Item>
                                                ))}
                                            </Dropdown.Menu>
                                        </Dropdown>
                                    </th>
                                    <th className="align-middle text-nowrap">TỒN KHO</th>
                                    <th className="align-middle text-nowrap">ĐƠN VỊ</th>
                                    <th className="align-middle text-nowrap">NGÀY NHẬP KHO</th>
                                    <th className="align-middle text-nowrap">HẠN BẢO HÀNH</th>
                                    <th className="align-middle text-nowrap">BARCODE</th>
                                    <th className="align-middle text-nowrap">TÌNH TRẠNG</th>
                                    <th className="align-middle text-nowrap position-sticky sticky-right"></th>
                                </tr>
                            </thead>

                            <tbody>
                                {listGoods && listGoods.length > 0 &&
                                    listGoods.map((g, index) => (
                                        <tr key={`goods${index}`}>
                                            <td className="align-middle text-color-primary">{index + 1}</td>
                                            <td className="align-middle text-color-primary">{g.goodsCode}</td>
                                            <td className="align-middle">{g.goodsName}</td>
                                            <td className="align-middle">{g.image}</td>
                                            <td className="align-middle">{g.supplierName}</td>
                                            <td className="align-middle">{g.categoryName}</td>
                                            <td className="align-middle">{g.inStock}</td>
                                            <td className="align-middle">{g.defaultMeasuredUnit}</td>
                                            <td className="align-middle">{g.warrantyTime}</td>
                                            <td className="align-middle">{g.warrantyTime}</td>
                                            <td className="align-middle">{g.barcode}</td>
                                            <td className="align-middle">{g.status}</td>
                                            <td className="align-middle " style={{ padding: '10px' }}>
                                                <a href="/EditProduct" className='' >
                                                    <i className="fa-duotone fa-pen-to-square actionButtonCSS" ></i>
                                                </a>
                                                &nbsp;
                                                <a href="/DeleteProduct">
                                                    <i className="fa-duotone fa-trash-alt actionButtonCSS" ></i>
                                                </a>
                                            </td>
                                        </tr>
                                    ))

                                }

                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
        </div >
    );
}

export default MyTable;
