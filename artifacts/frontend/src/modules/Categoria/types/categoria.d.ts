export type Categoria = {
  nome : string
Id : string

}

export type CategoriaCreateReq = Pick<Categoria, "nome">


export type CategoriaListRes = {
  "@odata.context": string
  value: Categoria[]
}

export type CategoriaCreateRes = {
  statusCode: number
  uri: string
  message: string
}

export type CategoriaGetRes = CategoriaListRes


export type CategoriaUpdateRes = {
  statusCode: number
  message: string
}

export type CategoriaDeleteRes = CategoriaUpdateRes