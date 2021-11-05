import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorsService } from 'src/app/data-access/authors.service';
import { IAuthorResolved } from 'src/app/data-structures/interfaces/IAuthorResolved';
import { Author } from 'src/app/data-structures/models/Author';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css']
})
export class AuthorEditComponent implements OnInit {
  pageTitle = 'Author Edit';
  errorMessage: string;
  authorEditForm : FormGroup;

  private dataIsValid: { [key: string]: boolean } = {};

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private authorsService: AuthorsService) { 
      this.instantiateAuthorForm();
    }

  private instantiateAuthorForm() {
    this.authorEditForm = this.formBuilder.group({
    id: [-999, Validators.required],
    firstName: ["", Validators.required],
    lastName: ["", Validators.required],
    authorCode: [""],
    address: ["", Validators.required],
    city: ["", Validators.required],
    zipCode: ["", Validators.required],
    phoneNumber: ["", Validators.required],
    contract: ["false"]
  });
  }

  ngOnInit(): void {
    const resolvedData: IAuthorResolved = this.route.snapshot.data['resolvedData'];
    this.errorMessage = resolvedData.error;
    this.onAuthorRetrieved(resolvedData.author);
  }

  onAuthorRetrieved(author: Author): void {
    if (author) {
      this.pageTitle = `Author Detail: ${author.firstName} ${author.lastName}`;
      this.authorEditForm.patchValue(author);
    } else {
      this.pageTitle = 'No author found';
    }
  }

  submitted = false;

  saveAuthor(): void {
    this.submitted = true;

    console.log(this.authorEditForm.value);

    this.authorsService.updateAuthor(this.authorEditForm.value).subscribe(
      data => {
        console.log('Author Updated Succeeded')
        this.router.navigate([`/editors/authors/${this.authorEditForm.controls['id'].value}`]);
      },
      error => {console.log('Author Updated Failed')}
    )
  }

  isValid(path?: string): boolean {
    this.validate();
    if (path) {
      return this.dataIsValid[path];
    }
    return (this.dataIsValid &&
      Object.keys(this.dataIsValid).every(d => this.dataIsValid[d] === true));
  }

  validate(): void {

  }
}
