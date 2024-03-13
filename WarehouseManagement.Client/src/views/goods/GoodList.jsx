import React, { useEffect, useState } from 'react';
import { Table, DropdownButton, DropdownMenu } from 'react-bootstrap';
import { fetchGoodsWithFilter } from '~/services/GoodServices';
import Dropdown from 'react-bootstrap/Dropdown';
import { Form } from 'react-bootstrap';
import { fetchAllCategories } from '~/services/CategoryServices';
import { fetchAllSuppliers } from '~/services/SupplierServices';
import { fetchAllStorages } from '~/services/StorageServices';
import { CustomToggle, CustomMenu } from '../components/others/Dropdown';

function MyTable() {
    const [listGoods, setListGoods] = useState({});

    const [totalCategories, setTotalCategories] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [selectedCategoryId, setSelectedCategoryId] = useState(null);

    const [totalSuppliers, setTotalSuppliers] = useState([]);
    const [selectedSupplier, setSelectedSupplier] = useState(null);
    const [selectedSupplierId, setSelectedSupplierId] = useState(null);

    const [totalStorages, setTotalStorages] = useState([]);
    const [selectedStorage, setSelectedStorage] = useState(null);
    const [selectedStorageId, setSelectedStorageId] = useState(null);

    useEffect(() => {
        let res = getGoods(1);
        getAllCategories();
        getAllSuppliers();
        getAllStorages();
    }, [])

    useEffect(() => {
        getGoods(1, selectedCategoryId, selectedSupplierId);
    }, [selectedCategory, selectedSupplier])

    const getGoods = async (page, categoryId, supplierId) => {
        let res = await fetchGoodsWithFilter(page, categoryId, supplierId);
        console.log(res);
        setListGoods(res.data);
        return res;
    }

    const getAllCategories = async () => {
        let res = await fetchAllCategories();
        setTotalCategories(res);
    }

    const getAllSuppliers = async () => {
        let res = await fetchAllSuppliers();
        setTotalSuppliers(res);
    }

    const getAllStorages = async () => {
        let res = await fetchAllStorages();
        setTotalStorages(res);
    }

    const handleCategoryClick = (category, event) => {
        setSelectedCategory(category.categoryName);
        setSelectedCategoryId(category.categoryId)
    }

    const handleSupplierClick = (supplier, event) => {
        setSelectedSupplier(supplier.supplierName);
        setSelectedSupplierId(supplier.supplierId)
    }

    const handleSupplierClickTotal = () => {
        setSelectedSupplier("Nhà cung cấp");
        setSelectedSupplierId("");
    }

    const handleCategoryClickTotal = () => {
        setSelectedCategory("Các danh mục");
        setSelectedCategoryId("");
    }

    const handleStorageClick = (storage) => {
        setSelectedStorage(storage.storageName);
        setSelectedStorageId(storage.storageId);
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-sm-12">
                    <h5 style={{ color: '#a5a2ad' }}>Trang chủ/Quản lý hàng hóa</h5>
                    <div className="row no-gutters my-3 ">
                        <div className="col">
                            <DropdownButton className="DropdownButtonCSS" title={selectedStorage !== null ? selectedStorage : "Kho"} variant="success">
                                {totalStorages && totalStorages.length > 0 && totalStorages.map((c, index) => (
                                    <Dropdown.Item key={`storage ${index}`} eventKey={c.storageName} onClick={(e) => handleStorageClick(c, e)}>{c.storageName}</Dropdown.Item>
                                ))}
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

                                    {/* <th className="align-middle  text-nowrap">
                                        <DropdownButton className="DropdownButtonCSS" title={selectedCategory !== null ? selectedCategory : "Danh mục"} variant="success">
                                            {totalCategories && totalCategories.length > 0 && totalCategories.map((c, index) => (
                                                <Dropdown.Item key={`category ${index}`} eventKey={c.categoryName} onClick={(e) => handleCategoryClick(c.categoryName, e)}>{c.categoryName}</Dropdown.Item>
                                            ))}
                                        </DropdownButton>


                                    </th> */}
                                    <th className="align-middle text-nowrap" style={{ overflow: 'visible' }}>
                                        <Dropdown style={{ position: 'relative' }}>
                                            <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                                                <span style={{ color: 'white' }}>{selectedSupplier !== null ? selectedSupplier : "Nhà cung cấp"}</span>
                                            </Dropdown.Toggle>

                                            <Dropdown.Menu as={CustomMenu} style={{ position: 'absolute', zIndex: '9999' }}>
                                                <Dropdown.Item onClick={handleSupplierClickTotal}>
                                                    Nhà cung cấp
                                                </Dropdown.Item>
                                                {totalSuppliers && totalSuppliers.length > 0 && totalSuppliers.map((s, index) => (
                                                    <Dropdown.Item key={`supplier ${index}`} eventKey={s.supplierName} onClick={(e) => handleSupplierClick(s, e)}>
                                                        {s.supplierName}
                                                    </Dropdown.Item>
                                                ))}
                                            </Dropdown.Menu>
                                        </Dropdown>
                                    </th>

                                    <th className="align-middle text-nowrap" style={{ overflow: 'visible' }}>
                                        <Dropdown style={{ position: 'relative' }}>
                                            <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                                                <span style={{ color: 'white' }}>{selectedCategory !== null ? selectedCategory : "Danh mục"}</span>
                                            </Dropdown.Toggle>

                                            <Dropdown.Menu as={CustomMenu} style={{ position: 'absolute', zIndex: '9999' }}>
                                                <Dropdown.Item onClick={handleCategoryClickTotal}>
                                                    Các danh mục
                                                </Dropdown.Item>
                                                {totalCategories && totalCategories.length > 0 && totalCategories.map((c, index) => (
                                                    <Dropdown.Item key={`category ${index}`} eventKey={c.categoryName} onClick={(e) => handleCategoryClick(c, e)}>
                                                        {c.categoryName}
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
