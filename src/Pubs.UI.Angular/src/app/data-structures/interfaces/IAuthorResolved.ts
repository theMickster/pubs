import { Author } from "../models/Author";

export interface IAuthorResolved {
    author: Author;
    error?: any;
  }