export type Usuario = {
  nome : string
_email : email
senha : string
Id : string

}

export type UsuarioCreateReq = Pick<Usuario, "nome" | "_email" | "senha">


export type UsuarioListRes = {
  "@odata.context": string
  value: Usuario[]
}

export type UsuarioCreateRes = {
  statusCode: number
  uri: string
  message: string
}

export type UsuarioGetRes = UsuarioListRes


export type UsuarioUpdateRes = {
  statusCode: number
  message: string
}

export type UsuarioDeleteRes = UsuarioUpdateRes