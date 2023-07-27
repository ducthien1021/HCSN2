const MISAResource = {
    VN: {
        Dialog: {
            Button: {
                Cancel: "Hủy bỏ",
                No: "Không",
                Save: "Lưu",
                NoSave: "Không lưu",
                Delete: "Xóa",
                Close: "Đóng",
                Yes: "Đồng ý"
            },
            WarningAdd: {
                Text: "Bạn có muốn hủy bỏ khai báo tài sản này?",
            },
            WarningEdit: {
                Text: "Thông tin thay đổi sẽ không được cập nhật nếu bạn không lưu. Bạn có muốn lưu các thay đổi này?",
            },
            DeleteOne: {
                text(data) {
                    return `Bạn có muốn xóa tài sản <b>${data}</b>?`
                }
            },
            DeleteMultiple: {
                text(quantity) {
                    if (quantity < 10) {
                        quantity = `0${quantity}`;
                    }
                    return `<b>${quantity}</b> tài sản đã được chọn. Bạn có muốn xóa các tài sản này khỏi danh sách?`
                },
            },
            InValidStartUsingDate: {
                Text: "Ngày mua phải nhỏ hơn hoặc bằng ngày sử dụng tài sản."
            },
            InValidDepreciationValue: {
                Text: "Hao mòn năm phải nhỏ hơn hoặc bằng nguyên giá."
            },
            InValidDepreciationRate: {
                Text: "Tỷ lệ hao mòn phải bằng 1/Số năm sử dụng."
            }
        },
        Toast: {
            InsertSuccess: "Lưu dữ liệu thành công!",
            UpdateSuccess: "Cập nhật dữ liệu thành công!"
        },
        Table: {
            EmptyData: "Không có dữ liệu",
            HeaderColumn: {
                SortOrder: {
                    Text: "STT",
                    Tooltip: "Số thứ tự"
                },
                AssetCode: {
                    Text: "Mã tài sản",
                },
                AssetName: {
                    Text: "Tên tài sản",
                },
                AssetCategoryName: {
                    Text: "Loại tài sản",
                },
                Department: {
                    Text: "Bộ phận sử dụng",
                },
                Quantity: {
                    Text: "Số lượng",
                },
                Cost: {
                    Text: "Nguyên giá"
                },
                Function: {
                    Text: "Chức năng"
                }
            }
        },
        Button: {
            Cancel: "Hủy",
            Save: "Lưu"
        },
        AssetForm: {
            Title: {
                Add: "Thêm tài sản",
                Edit: "Sửa tài sản"
            },
            fixed_asset_code: {
                Label: "Mã tài sản",
                Placeholder: "Nhập mã tài sản",
                EmptyMsgError: "Mã tài sản không được để trống."
            },
            fixed_asset_name: {
                Label: "Tên tài sản",
                Placeholder: "Nhập tên tài sản",
                EmptyMsgError: "Tên tài sản không được để trống."
            },
            department_code: {
                Label: "Mã bộ phận sử dụng",
                Placeholder: "Chọn mã bộ phận sử dụng",
                EmptyMsgError: "Mã bộ phận sử dụng không được để trống."
            },
            department_name: {
                Label: "Tên bộ phận sử dụng",
            },
            fixed_asset_category_code: {
                Label: "Mã loại tài sản",
                Placeholder: "Chọn mã loại tài sản",
                EmptyMsgError: "Mã loại tài sản không được để trống."
            },
            fixed_asset_category_name: {
                Label: "Tên loại tài sản",
            },
            quantity: {
                Label: "Số lượng",
                EmptyMsgError: "Số lượng không được để trống."
            },
            cost: {
                Label: "Nguyên giá",
                EmptyMsgError: "Nguyên giá không được để trống."
            },
            life_time: {
                Label: "Số năm sử dụng",
                EmptyMsgError: "Số năm sử dụng không được để trống."
            },
            depreciation_value: {
                Label: "Giá trị hao mòn năm",
                EmptyMsgError: "Giá trị hao mòn năm không được để trống."
            },
            depreciation_rate: {
                Label: "Tỉ lệ hao mòn (%)",
                EmptyMsgError: "Tỉ lệ hao mòn (%) không được để trống."
            },
            tracked_year: {
                Label: "Năm theo dõi",
            },
            purchase_date: {
                Label: "Ngày mua",
                EmptyMsgError: "Ngày mua không được để trống."
            },
            start_using_date: {
                Label: "Ngày bắt đầu sử dụng",
                EmptyMsgError: "Ngày bắt đầu sử dụng không được để trống."
            },
        },
        Sidebar: {
            General: {
                Text: "Tổng quan",
            },
            Asset: {
                Text: "Tài sản",
            },
            AssetRoadInfrastructure: {
                Text: "Tài sản HT-ĐB",
                Tooltip: "Tài sản hạ tầng đường bộ"
            },
            Tool: {
                Text: "Công cụ dụng cụ"
            },
            Category: {
                Text: "Danh mục"
            },
            Search: {
                Text: "Tra cứu"
            },
            Report: {
                Text: "Báo cáo"
            }
        },
        Header: {
            TitleLeft: "Danh sách tài sản",
            TitleRight: "Sở tài chính",
            NotiButton: "Thông báo",
            CategoryButton: "Danh mục",
            QuesButton: "Hỏi đáp",
            ProfileButton: "Trang cá nhân"
        },
        AssetPage: {
            Button: "Button"
        }
    }
}


export default MISAResource