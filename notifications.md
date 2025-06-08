# 🧩 Module: Service Management – Low-Level Design (LLD)

## 1. Mục tiêu

- Cho phép End User đăng ký, kích hoạt/deactive các dịch vụ (service) mặc định của hệ thống hoặc tự tạo.
- Quản lý quy trình duyệt (approve/reject) service do user tạo hoặc update.
- Admin có thể CRUD service hệ thống (is_system=true) và duyệt các yêu cầu tạo/cập nhật service của user.
- Lưu vết lịch sử duyệt, trạng thái từng lần đăng ký/cập nhật service.
- Hỗ trợ multi-business (business_id).

---

## 2. Entities

### services

- `id` (uuid, PK): ID dịch vụ
- `business_id` (uuid, FK, not null): Service thuộc business nào
- `name` (string, not null): Tên dịch vụ
- `description` (string): Mô tả dịch vụ
- `points` (decimal, not null): Số điểm khi thực hiện dịch vụ
- `image_url` (string): Ảnh dịch vụ
- `is_system` (boolean, not null): true: service hệ thống (admin tạo), false: user tạo
- `created_by` (uuid, not null): Ai tạo service này (admin/user)
- `updated_by` (uuid)
- `created_at` (timestamp, not null)
- `updated_at` (timestamp)
- `is_active` (boolean, not null)

### user_services

- `id` (uuid, PK): ID
- `user_id` (uuid, not null): Ai sở hữu/đăng ký service này
- `service_id` (uuid, not null): FK đến services
- `status` (enum, not null): pending, active, deactivated, rejected
- `created_by` (uuid, not null)
- `updated_by` (uuid)
- `created_at` (timestamp, not null)
- `updated_at` (timestamp)
- `is_active` (boolean, not null)

### service_approvals

- `id` (uuid, PK): ID
- `user_service_id` (uuid, not null): FK đến user_services
- `status` (enum, not null): pending, approved, rejected
- `comment` (string): Lý do duyệt/từ chối
- `payload` (jsonb): Lưu trữ data khi user yêu cầu update
- `created_by` (uuid, not null)
- `updated_by` (uuid)
- `created_at` (timestamp, not null)
- `updated_at` (timestamp)
- `is_active` (boolean, not null)

---

## 2.1 Database diagram

```mermaid
erDiagram
  businesses {
    uuid id PK
    string name
    string description
    string address
    string phone_number
    string email
    boolean is_active
    timestamp created_at
    timestamp updated_at
    uuid created_by
    uuid updated_by
  }
  users {
    uuid id PK
    uuid business_id FK
    string first_name
    string last_name
    string email
    string phone_number
    string address
    string password
    timestamp last_login
    enum role
    string avatar
    boolean is_active
    timestamp created_at
    timestamp updated_at
    uuid created_by
    uuid updated_by
  }
  services {
    uuid id PK
    uuid business_id FK
    string name
    string description
    decimal points
    string image_url
    boolean is_system
    uuid created_by
    uuid updated_by
    timestamp created_at
    timestamp updated_at
    boolean is_active
  }
  user_services {
    uuid id PK
    uuid user_id FK
    uuid service_id FK
    enum status
    uuid created_by
    uuid updated_by
    timestamp created_at
    timestamp updated_at
    boolean is_active
  }
  service_approvals {
    uuid id PK
    uuid user_service_id FK
    enum status
    string comment
    jsonb payload
    uuid created_by
    uuid updated_by
    timestamp created_at
    timestamp updated_at
    boolean is_active
  }
  businesses ||--o{ services : "owns"
  businesses ||--o{ users : "has"
  users ||--o{ user_services : "has"
  services ||--o{ user_services : "has"
  user_services ||--o{ service_approvals : "has"
```

---

## 3. Use Cases & API Design

### 3.1 Lấy danh sách service hệ thống (Admin/End User)

```shell
GET /api/services?is_system=true&limit=10&offset=0&search=text
```

**Params:**

- `is_system` (boolean, required): true để lấy service hệ thống
- `limit` (integer, optional): số lượng record trả về (default: 10)
- `offset` (integer, optional): vị trí bắt đầu (default: 0)
- `search` (string, optional): tìm kiếm theo tên/mô tả service

**Response:**

```json
{
  "data": [
    {
      "id": "uuid",
      "business_id": "uuid",
      "name": "Featherlight Assistance",
      "description": "Easy support",
      "points": 1.0,
      "image_url": "...",
      "is_system": true,
      "is_active": true
    }
  ],
  "meta": {
    "count": 1,
    "limit": 10,
    "offset": 0,
    "search": ""
  }
}
```

**Sequence diagram:**

```mermaid
sequenceDiagram
  participant Client
  participant API as API Server
  participant DB as Database

  Client->>API: GET /api/services?is_system=true&limit=10&offset=0&search=text
  API->>DB: Query services (is_system=true, is_active=true, search, limit, offset)
  DB-->>API: Return filtered services
  API-->>Client: Return 200 OK with data and meta
```

**Logic:**

- Extract user from request và lấy `business_id` từ auth context (hoặc tạm dùng `business_id` của ABC Rewards site - đối với admin).
- Query `services` với `business_id`, `is_system=true`, `is_active=true`, `search`, `limit`, `offset`.
- Nếu có `search`, tìm kiếm theo `name` hoặc `description`.
- Phân trang với `limit` và `offset`.
- Trả về `data` (danh sách service) và `meta` (tổng số record, limit, offset, search).

---

### 3.2 Tạo service (Admin/User)

```shell
POST /api/services
```

**Payload:**

```json
{
  "name": "Service Name",
  "description": "Service description",
  "points": 5.0,
  "image_url": "...",
  "is_system": false
}
```

**Response (Success):**

```json
{
  "data": {
    "id": "uuid",
    "business_id": "uuid",
    "name": "Service Name",
    "description": "Service description",
    "points": 5.0,
    "image_url": "...",
    "is_system": false,
    "is_active": true,
    "created_at": "...",
    "user_service": {
      "id": "uuid",
      "status": "pending"
    }
  }
}
```

**Sequence Diagram:**

```mermaid
sequenceDiagram
    participant Client
    participant API as API Server
    participant DB as Database

    Client->>API: POST /api/services with payload
    Note over API: Extract business_id, user_id, role from auth context

    alt Admin Flow (is_system: true)
        Note over API: Check if role is Admin
        API->>DB: Create services record (created_by = user_id)
        DB-->>API: Return created service
        API-->>Client: Return 201 Created (gồm service và user_service)
    end

    alt User Flow (is_system: false)
        Note over API: Check if role is User
        API->>DB: Begin Transaction
        API->>DB: Create services record (created_by = user_id)
        API->>DB: Create user_services record (user_id, service_id, status='pending')
        API->>DB: Create service_approvals record (user_service_id, status='pending')
        DB-->>API: Return created data
        API->>DB: Commit Transaction
        API-->>Client: Return 201 Created (gồm service và user_service)
    end
```

**Logic:**

- Extract `business_id`, `user_id`, và `role` từ auth context.
- **Admin Flow:**
  - Nếu `role` là Admin và `is_system: true` trong payload, chỉ tạo record trong `services`.
  - `created_by` là `admin_id`.
- **User Flow:**
  - Nếu `role` là User và `is_system: false` trong payload:
  - Start transaction.
  - Tạo record trong `services` với `is_system: false`, `created_by = user_id`.
  - Dùng `service_id` vừa tạo, tạo record trong `user_services` với `status: 'pending'`.
  - Dùng `user_service_id` vừa tạo, tạo record trong `service_approvals` với `status: 'pending'`.
  - Commit transaction.
- Trả về dữ liệu tương ứng.

---

### 3.3 Cập nhật service hệ thống (Admin)

```shell
PUT /api/services/{id}
```

**Payload:**

```json
{
  "name": "Featherlight Assistance Updated",
  "description": "Updated description",
  "points": 2.5,
  "image_url": "...",
  "is_active": true
}
```

**Response:**

```json
{
  "data": {
    "id": "uuid",
    "name": "Featherlight Assistance Updated",
    "description": "Updated description",
    "points": 2.5,
    "image_url": "...",
    "is_active": true,
    "created_at": "2025-05-02T16:14:00.000Z",
    "updated_at": "2025-05-02T16:15:00.000Z"
  }
}
```

**Sequence diagram:**

```mermaid
sequenceDiagram
  participant Client
  participant API as API Server
  participant DB as Database

  Client->>API: PUT /api/services/{id} with payload
  Note over API: Extract business_id from admin auth context (hoặc tạm dùng business_id của ABC Rewards site)

  API->>DB: Query service with id, business_id
  DB-->>API: Return service data
  alt Service Not Found
      API-->>Client: Return 404 Not Found
  end

  API->>DB: Update service record
  DB-->>API: Return updated data
  API-->>Client: Return 200 OK with data
```

**Logic:**

- Extract `business_id` từ auth context (tạm dùng business_id của ABC Rewards site).
- Kiểm tra service tồn tại với id, business_id.
- Chỉ admin được phép cập nhật.
- Update các trường được gửi lên.
- Trả về toàn bộ object service đã cập nhật.

---

### 3.4 Xóa service hệ thống (Admin)

```shell
DELETE /api/services/{id}
```

**Response:**

```json
{
  "data": {
    "id": "uuid"
  }
}
```

**Sequence diagram:**

```mermaid
sequenceDiagram
  participant Client
  participant API as API Server
  participant DB as Database

  Client->>API: DELETE /api/services/{id}
  Note over API: Extract business_id from admin auth context (hoặc tạm dùng business_id của ABC Rewards site)

  API->>DB: Query service with id, business_id, is_active=true
  DB-->>API: Return service data
  alt Service Not Found
      API-->>Client: Return 404 Not Found
  end

  API->>DB: Check for active user_services with service_id
  DB-->>API: Return user_services count
  alt Active user_services exist
      API-->>Client: Return 400 Bad Request
  end

  API->>DB: Soft delete service (is_active=false, updated_by, updated_at)
  DB-->>API: Confirm deletion
  API-->>Client: Return 204 No Content
```

**Logic:**

- Extract `business_id` từ auth context (tạm dùng business_id của ABC Rewards site).
- Kiểm tra service tồn tại với id, business_id, is_active=true.
- Kiểm tra không có user_services active liên quan.
- Soft delete: set is_active=false, updated_by, updated_at cho service.
- Trả 204 No Content.

---

### 3.5 Lấy danh sách service của User (My Services)

```shell
GET /api/user-services/me?limit=10&offset=0&status=active
```

**Params:**

- `status` (string, optional): Lọc theo trạng thái (pending, active, deactivated, rejected).
- `limit` (integer, optional): default 10
- `offset` (integer, optional): default 0

**Response:**

```json
{
  "data": {
    "system_services": [
      {
        "id": "user_service_id_1",
        "status": "active",
        "service": {
          "id": "service_id_1",
          "name": "Featherlight Assistance",
          "description": "Easy support",
          "points": 1.0,
          "image_url": "...",
          "is_system": true
        }
      }
    ],
    "custom_services": [
      {
        "id": "user_service_id_2",
        "status": "pending",
        "service": {
          "id": "service_id_2",
          "name": "Tư vấn lô đề",
          "description": "Tư vấn lô đề, áp dụng xác suất thống kê để áp dụng cho dự đoán",
          "points": 2.0,
          "image_url": "...",
          "is_system": false
        }
      }
    ]
  },
  "meta": {
    "count": 2,
    "limit": 10,
    "offset": 0
  }
}
```

**Sequence diagram:**

```mermaid
sequenceDiagram
  participant Client
  participant API as API Server
  participant DB as Database

  Client->>API: GET /api/user-services/me
  Note over API: Extract user_id from auth context

  API->>DB: Query user_services by user_id, join with services
  DB-->>API: Return list of user services

  API->>Client: Group and return services
```

**Logic:**

- Trích xuất `user_id` từ auth context.
- Truy vấn `user_services` với điều kiện `user_id` khớp và `is_active=true`.
- Join với bảng `services` để lấy thông tin chi tiết của service.
- Lọc theo tham số `status` nếu được cung cấp.
- Phân trang kết quả.
- Nhóm kết quả thành `system_services` (với `services.is_system = true`) và `custom_services` (với `services.is_system = false`).
- Trả về dữ liệu có cấu trúc.

---

### 3.6 User đăng ký/kích hoạt service hệ thống

```shell
POST /api/user-services
```

**Payload:**

```json
{
  "service_id": "uuid_of_system_service"
}
```

**Response:**

```json
{
  "data": {
    "id": "uuid",
    "user_id": "user_id",
    "service_id": "uuid",
    "status": "active",
    "created_at": "2025-05-02T16:14:00.000Z"
  }
}
```

**Sequence diagram:**

```mermaid
sequenceDiagram
  participant User
  participant FE
  participant API as API Server
  participant DB as Database

  User->>FE: Chọn service hệ thống
  FE->>API: POST /api/user-services
  API->>DB: Check if service is_system=true and user is not already registered
  alt Service is a system service
    API->>DB: Insert user_services (status='active')
    DB-->>API: OK
    API-->>FE: Trả về trạng thái active
  else Service not system or already registered
     API-->>FE: Return 400 Bad Request
  end
```

**Logic:**

- Extract `user_id` và `business_id` từ auth context.
- Validate `service_id` tồn tại, thuộc `business_id`, và là service hệ thống (`is_system = true`).
- Kiểm tra user chưa có record `user_services` cho `service_id` này. Nếu đã có, trả về lỗi 409 Conflict.
- **Không tạo `service_approvals` record.**
- Tạo `user_services` record với `status = 'active'`.
- Logic này cho phép user kích hoạt và sử dụng service hệ thống ngay lập tức. Luồng duyệt chỉ áp dụng cho service do user tạo/cập nhật.

---

### 3.7 User cập nhật service của mình

```shell
PUT /api/services/{id}
```

**Payload:**

```json
{
  "name": "Dạy tiếng Anh nâng cao",
  "description": "1 buổi dạy nâng cao",
  "points": 3.5,
  "image_url": "..."
}
```

**Response (Success):**

```json
{
  "data": {
    "id": "uuid",
    "user_service_id": "uuid",
    "status": "pending"
  }
}
```

**Sequence Diagram:**

```mermaid
sequenceDiagram
    participant Client
    participant API as API Server
    participant DB as Database

    Client->>API: PUT /api/services/{id} with payload
    Note over API: Extract user_id, business_id from auth context

    API->>DB: Query services (id, business_id, created_by=user_id, is_system=false)
    DB-->>API: Return service data
    alt Service not found or user is not owner
        API-->>Client: Return 404/403 Forbidden
    end

    API->>DB: Query user_services (service_id, user_id)
    DB-->>API: Return user_service data
    alt User service not found or status is not 'active'/'deactivated'
        API-->>Client: Return 400 Bad Request
    end

    API->>DB: Begin Transaction
    API->>DB: Create service_approvals (user_service_id, status='pending', payload={...})
    API->>DB: Update user_services.status = 'pending'
    DB-->>API: Return approval data
    API->>DB: Commit Transaction

    API-->>Client: Return 201 Created with approval data
```

**Logic:**

- Extract `user_id`, `business_id` từ auth context.
- Validate service `{id}` tồn tại, thuộc `business_id`, là service custom (`is_system: false`), và do chính user này tạo (`created_by = user_id`).
- Tìm `user_services` tương ứng với `service_id` và `user_id`. Service phải đang ở trạng thái `active` hoặc `deactivated` mới được update.
- Start transaction.
- **Không cập nhật bảng `services` ngay.**
- Tạo một record mới trong `service_approvals` với:
  - `user_service_id` tìm được ở trên.
  - `status: 'pending'`.
  - `payload`: chứa toàn bộ payload của request.
- Cập nhật `status` của `user_services` thành `pending`.
- Commit transaction.
- Trả về thông tin của `service_approvals` vừa tạo.

---

### 3.8 User xóa service đã đăng ký

```shell
DELETE /api/user-services/{id}
```

**Params:**

- `{id}`: ID của bản ghi user_services (không phải id của services)

**Response:**

```json
{
  "data": {
    "id": "uuid"
  }
}
```

**Sequence diagram:**

```mermaid
sequenceDiagram
  participant User
  participant FE
  participant API as API Server
  participant DB as Database

  User->>FE: Click delete on a service in My Services
  FE->>API: DELETE /api/user-services/{id}
  Note over API: Extract user_id, business_id from auth context

  API->>DB: Query user_services with id, user_id, business_id, is_active=true
  DB-->>API: Return user_service data
  alt Not Found
      API-->>FE: Return 404 Not Found
  end

  API->>DB: Soft delete user_services (is_active=false, updated_by, updated_at)
  DB-->>API: Confirm deletion
  API-->>FE: Return 204 No Content
```

**Logic:**

- Extract `user_id`, `business_id` từ auth context.
- Kiểm tra user_services tồn tại với id, user_id, business_id, is_active=true.
- Soft delete: set is_active=false, updated_by, updated_at cho user_services.
- Trả 204 No Content.

---

### 3.9 User active/deactive service đã được duyệt

```shell
PATCH /api/user-services/{id}/status
```

**Payload:**

```json
{
  "status": "active"
}
```

**Response:**

```json
{
  "data": {
    "id": "uuid",
    "user_id": "uuid",
    "service_id": "uuid",
    "status": "active",
    "created_at": "...",
    "updated_at": "..."
  }
}
```

**Logic:**

- **Extract `business_id` từ user_service.service_id (truy vấn bảng services) hoặc từ auth context.**
- Chỉ cho phép khi user_services.status=`active` hoặc `deactivated`.
- Trả về toàn bộ object user_service đã cập nhật.

---

### 3.10 Admin duyệt yêu cầu (approve/reject)

**Lấy danh sách yêu cầu:**

```shell
GET /api/service-approvals?status=pending&limit=10&offset=0&search=text
```

**Params:**

- `status` (string, optional): pending, approved, rejected. Default: pending.
- `search` (string, optional): Tìm kiếm theo tên user hoặc tên service.
- `limit`, `offset`

**Response:**

```json
{
  "data": [
    {
      "id": "approval_id",
      "status": "pending",
      "comment": null,
      "created_at": "...",
      "user_service": {
        "id": "user_service_id",
        "user": {
          "id": "user_id",
          "name": "Huy Tran"
        },
        "service": {
          "id": "service_id",
          "name": "Tư vấn lô đề...",
          "description": "...",
          "points": 2,
          "image_url": "..."
        }
      },
      "payload": {
        "name": "Tên service mới",
        "points": 5.0
      }
    }
  ],
  "meta": { "count": 1, "limit": 10, "offset": 0 }
}
```

**Phê duyệt/Từ chối yêu cầu:**

```shell
PUT /api/service-approvals/{id}
```

**Payload:**

```json
{
  "status": "approved",
  "comment": "OK"
}
```

**Response:**

```json
{
  "data": {
    "id": "uuid",
    "status": "approved"
  }
}
```

**Logic:**

- **GET:**
  - Extract `business_id` từ admin auth context.
  - Query `service_approvals`, join với `user_services` -> `users` và `user_services` -> `services` để lấy đủ thông tin hiển thị.
  - Lọc theo `business_id`, `status`, `search`. Phân trang.
- **PUT:**
  - Tìm `service_approvals` bằng `{id}`. Validate nó thuộc `business_id`.
  - Start transaction.
  - Cập nhật `service_approvals` (status, comment, approver_id).
  - Dựa vào `service_approvals.payload`:
    - **Nếu `payload` là `null` (Yêu cầu tạo mới):**
      - Nếu `status: 'approved'`, cập nhật `user_services.status = 'active'`.
      - Nếu `status: 'rejected'`, cập nhật `user_services.status = 'rejected'`.
    - **Nếu `payload` có dữ liệu (Yêu cầu cập nhật):**
      - Nếu `status: 'approved'`:
        - Lấy dữ liệu từ `service_approvals.payload`.
        - Cập nhật record trong bảng `services` tương ứng.
        - Cập nhật `user_services.status = 'active'`.
      - Nếu `status: 'rejected'`, chỉ cần cập nhật `user_services.status = 'active'` (trả lại trạng thái cũ trước khi yêu cầu update).
  - Commit transaction.
  - Trả về `service_approvals` đã cập nhật.

---

### 3.11 Lấy chi tiết một service

```shell
GET /api/services/{id}
```

**Response:**

```json
{
  "data": {
    "id": "uuid",
    "business_id": "uuid",
    "name": "...",
    "description": "...",
    "points": 2.0,
    "image_url": "...",
    "is_system": false,
    "is_active": true
  }
}
```

**Logic:**

- Extract `business_id` từ auth context.
- Validate service thuộc business_id này.
- Trả về chi tiết service.

---

## 4. Logic tổng quát

- Phân biệt service hệ thống và user tạo: is_system (true/false).
- Quy trình duyệt: Yêu cầu tạo/cập nhật service của user sẽ đi qua bảng `service_approvals`. Service hệ thống không cần duyệt.
- Trạng thái user_services: pending → active/deactivated → rejected.
- User chỉ được active/deactive khi đã được duyệt (status=active hoặc status=deactivated).
- Admin CRUD service hệ thống (is_system=true).
- Chuẩn hóa multi-business: luôn extract và filter theo `business_id`.

---

## 5. UI/UX mapping

- **End user:**
  - Tab Explore: Xem service hệ thống (is_system=true) để đăng ký.
  - Tab My Services: Quản lý service đã đăng ký (`user_services`), hiển thị service hệ thống và service custom với các trạng thái:
    pending/active/deactivated/rejected.
  - Đăng ký mới (cho service hệ thống), tạo mới (service custom), cập nhật, active/deactive, xóa.
- **Admin portal:**
  - Quản lý service hệ thống (CRUD).
  - Duyệt các yêu cầu tạo/cập nhật service của user (`service_approvals`).

---

## 6. Notes

- Có thể mở rộng thêm các trường về thời gian hiệu lực, version, metadata nếu cần.
- Chuẩn hóa với các module khác như reward-management, evidence, user-transactions.

---
