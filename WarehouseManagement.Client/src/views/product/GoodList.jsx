import React, { useEffect, useState } from 'react';
import { Table, DropdownButton, Dropdown } from 'react-bootstrap';
import { fetchGoodsWithFilter } from '~/services/GoodServices';
import { Form } from 'react-bootstrap';
import { fetchAllCategories } from '~/services/CategoryServices';

function MyTable() {
    const [listGoods, setListGoods] = useState({});

    const [selectedCategory, setSelectedCategory] = useState(null);
    const [totalCategories, setTotalCategories] = useState([]);

    useEffect(() => {
        getGoods(1);
        getAllCategories();
    }, [])

    const getGoods = async (page) => {
        let res = await fetchGoodsWithFilter(1);
        setListGoods(res.data);
    }

    const getAllCategories = async () => {
        let res = await fetchAllCategories();
        setTotalCategories(res);
    }

    const handleCategoryClick = (eventKey, event) => {
        setSelectedCategory(eventKey);
        console.log(event);
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

                    <div className=" table-responsive">
                        <Table className="table text-center table-border table-hover  border-primary table-sm ">

                            <thead>
                                <tr>
                                    <th className="align-middle text-nowrap position-sticky sticky-left">STT</th>
                                    <th className="align-middle text-nowrap">Mã SP</th>
                                    <th className="align-middle textColor text-nowrap">TÊN SẢN PHẨM</th>
                                    <th className="align-middle text-nowrap">Hình ảnh</th>
                                    <th className="align-middle">
                                        <Form.Select aria-label="Default select example" className='formSelectCSS text-nowrap w-auto'>
                                            <option value="">Tất cả</option>
                                            <option value="1">Đang hợp tác</option>
                                            <option value="2">Ngừng hợp tác</option>
                                        </Form.Select>
                                    </th>
                                    <th className="align-middle  text-nowrap">
                                        <DropdownButton className="DropdownButtonCSS" title={selectedCategory !== null ? selectedCategory : "Danh mục"} variant="success">
                                            {totalCategories && totalCategories.length > 0 && totalCategories.map((c, index) => (
                                                <Dropdown.Item key={`category ${index}`} eventKey={c.categoryName} onClick={(e) => handleCategoryClick(c.categoryName, e)}>{c.categoryName}</Dropdown.Item>
                                            ))}
                                        </DropdownButton>


                                    </th>
                                    <th className="align-middle text-nowrap">TỒN KHO</th>
                                    <th className="align-middle text-nowrap">ĐƠN VỊ</th>
                                    <th className="align-middle text-nowrap">NGÀY nhập kho</th>
                                    <th className="align-middle text-nowrap">Hạn bảo hành</th>
                                    <th className="align-middle text-nowrap">Barcode</th>
                                    <th className="align-middle text-nowrap">Tình trạng</th>
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