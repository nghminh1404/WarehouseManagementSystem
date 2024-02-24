import React from 'react';
import { Table } from 'react-bootstrap';


function MyTable() {
  return (
    <div className="container text-center">
      <div className="row">
        <div className="col-sm-3">
          Level 1: .col-sm-3
        </div>
        <div className="col-sm-9">
          <div className="row">
            <div className="col">
              <h5 style={{ marginTop: '90px', paddingRight: '700px' }}>Trang chủ/Quản lý hàng hóa</h5>
              <Table bordered style={{ border: '1px solid #dee2e6' }} hover>
                <thead>
                  <tr>
                    <th class="text-nowrap">Mã SP</th>
                    <th class="text-nowrap">TÊN SẢN PHẨM</th>
                    <th class="text-nowrap">NHÀ CUNG CẤP</th>
                    <th class="text-nowrap">LOẠI</th>
                    <th class="text-nowrap">TÓN KHO</th>
                    <th class="text-nowrap">ĐƠN VỊ</th>
                    <th class="text-nowrap">NGÀY KHỞI TẠO</th>
                    <th class="text-nowrap">ORDER STATUS</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td class="text-primary">SP1</td>
                    <td> 
                      OnePlues 7Pro</td>
                    <td>OnePlues</td>
                    <td>SmartPhone</td>
                    <td>102</td>
                    <td>Chiec</td>
                    <td>17/02/2003</td>
                    <td class="text-success">Đang giao dịch</td>
                    <td style={{padding: '20px'}}><i class="fa-solid fa-pen-to-square"></i></td>
                  </tr>
                  <tr>
                    <td class="text-primary">SP2</td>
                    <td> 
                      OnePlues 7Pro</td>
                    <td>OnePlues</td>
                    <td>SmartPhone</td>
                    <td>102</td>
                    <td>Chiec</td>
                    <td>17/02/2003</td>
                    <td class="text-danger">Dừng giao dịch</td>
                    <td style={{padding: '20px'}}><i class="fa-solid fa-pen-to-square"></i></td>
                  </tr>
                  <tr>
                    <td class="text-primary">SP3</td>
                    <td> 
                      OnePlues 7Pro</td>
                    <td>OnePlues</td>
                    <td>SmartPhone</td>
                    <td>102</td>
                    <td>Chiec</td>
                    <td>17/02/2003</td>
                    <td class="text-danger">Dừng giao dịch</td>
                    <td style={{padding: '20px'}}><i class="fa-solid fa-pen-to-square"></i></td>
                  </tr>
                  <tr>
                    <td class="text-primary">SP4</td>
                    <td> 
                      OnePlues 7Pro</td>
                    <td>OnePlues</td>
                    <td>SmartPhone</td>
                    <td>102</td>
                    <td>Chiec</td>
                    <td>17/02/2003</td>
                    <td class="text-success">Đang giao dịch</td>
                    <td style={{padding: '20px'}}><i class="fa-solid fa-pen-to-square"></i></td>
                  </tr>
                </tbody>
              </Table>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default MyTable;