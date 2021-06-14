import { Component, OnInit } from '@angular/core';
import { EmployeeApiService } from 'src/app/data/service/employee-api.service';
import { Employee } from 'src/app/data/type/employee';
import * as $ from "jquery";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  Employees = new Array<Employee>();
  IdEmployeeUpdate!: number;
  ActionStatus: string = "create";
  constructor(private EmployeeApiService: EmployeeApiService) { }

  ngOnInit(): void {
    this.GetAllEmployee();
  }

  GetAllEmployee() {
    this.EmployeeApiService.GetAll().subscribe(Employees => {
      this.Employees = Employees;
    })
  }

  CreateEmployee() {
    let name = $("#name").val();
    let phoneNumber = $("#phoneNumber").val();
    let email = $("#email").val();
    let isWork = $("#isWork").prop("checked");

    let EmployeeAdd = { name: name, phoneNumber: phoneNumber, email: email, status: isWork };

    if (this.Validate()) {
      console.log(EmployeeAdd);
      this.EmployeeApiService.Create(EmployeeAdd).subscribe(
        Employee => {
          this.Employees.unshift(Employee);
          console.log(Employee);
          this.ClearInfo();
        },
        err => {
          console.log(err);
        });
    }
  }

  ClearInfo() {
    $("#name").val("");
    $("#phoneNumber").val("");
    $("#email").val("");
    $("#isWork").prop("checked", false);
  }

  SetInfo(Id: number) {
    this.IdEmployeeUpdate = Id;
    let index = this.Employees.findIndex(Item => Item.id == Id);
    let EmployeeUpdate = this.Employees.slice(index, index + 1);
    $("#name").val(EmployeeUpdate[0].name);
    $("#phoneNumber").val(EmployeeUpdate[0].phoneNumber);
    $("#email").val(EmployeeUpdate[0].email);
    $("#isWork").prop("checked", EmployeeUpdate[0].status);

    this.ActionStatus="update";
  }

  UpdateEmployee() {
    let name = $("#name").val() + "";
    let phoneNumber = $("#phoneNumber").val() + "";
    let email = $("#email").val() + "";
    let isWork = $("#isWork").prop("checked");

    if (this.Validate()) {
      let EmployeeUpdate = new Employee(this.IdEmployeeUpdate, name, phoneNumber, email, isWork);
      this.EmployeeApiService.Update(EmployeeUpdate, this.IdEmployeeUpdate).subscribe(Employee => {
        let index = this.Employees.findIndex(Item => Item.id == this.IdEmployeeUpdate);
        this.Employees[index] = Employee;
        this.ClearInfo();
        this.ActionStatus="create";
      });
    }
  }

  DeleteEmployee(Id: number) {
    this.EmployeeApiService.Delete(Id).subscribe(Employee => {
      let index = this.Employees.findIndex(Item => Item.id == Employee.id);
      this.Employees.splice(index, 1);
      this.ClearInfo();
      this.ActionStatus="create";
    })
  }

  Validate() {
    $("#message_validate_name").html("");
    $("#message_validate_phoneNumber").html("");
    $("#message_validate_email").html("");

    let name = $("#name").val() + "";
    if (name == "") {
      $("#message_validate_name").html("Name is invalid!");
      return false;
    }

    let phoneNumber = $("#phoneNumber").val() + "";
    if (phoneNumber == "") {
      $("#message_validate_phoneNumber").html("Phone number is invalid!");
      return false;
    }

    let email = $("#email").val();
    if (email == "") {
      $("#message_validate_email").html("Email is invalid!");
      return false;
    }

    return true;
  }

  cancelUpdate(){
    this.ClearInfo();
    this.ActionStatus="create";
  }
}
