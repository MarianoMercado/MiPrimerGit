Imports CnSistemas
Public Class Vehiculos_Listar
    Inherits System.Web.UI.Page
    Dim OAspirantes As New CnAspirantes
    Dim OCursos As New CnCursos
    Dim odDataset As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            CARGARGRILLA()
            cargoGenero()
        End If



    End Sub
    Public Sub cargoGenero()
        Dim oGenero As New CnGeneros
        Dim oDs As New DataSet
        oDs = oGenero.TraerTodos()
        DDLGenero.DataSource = oDs
        DDLGenero.DataTextField = "DESCRIPCION"
        DDLGenero.DataValueField = "ID"
        DDLGenero.DataBind()
    End Sub
    Public Sub CARGARGRILLA()
        odDataset = OAspirantes.TraerTodos
        GdvVehiculos.DataSource = odDataset
        GdvVehiculos.DataBind()
    End Sub

    Private Sub GdvColores_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GdvVehiculos.RowCommand


        Dim indice As Integer = e.CommandArgument

        Dim row As GridViewRow = GdvVehiculos.Rows(indice)
        Dim ID As Integer = Convert.ToInt32(CType(row.FindControl("ID"), Label).Text)


        Select Case e.CommandName

            'Case "Eliminar"

            '    Try

            '        lblALIQUIDACION_ELIMINAR.Text = "Esta seguro que desa Eliminar el Registro!!!, <br><font color='red'>Se van a Eliminar el Color Cargado!!!</font>"
            '        ColorEliminar.Text = Convert.ToString(CType(row.FindControl("ID"), Label).Text)

            '        If (Not ClientScript.IsStartupScriptRegistered("fnEliminarColor")) Then

            '            Page.ClientScript.RegisterStartupScript(Me.GetType(), "fnEliminarColor", "fnEliminarColor();", True)

            '        End If

            '    Catch ex As Exception

            ' Mostrar_Mensaje("Ha ocurrido la Siguiente Excepción: " & ex.Message)

            'Finally




            '    End Try



            Case "Editar"

                Try

                    lblALIQUIDACION_ELIMINAR.Text = "Esta seguro que desa Editar el Registro!!!, <br><font color='red'>Se va a  Editar el Color Cargado!!!</font>"

                    txtIdColorEditar.Text = Convert.ToString(CType(row.FindControl("ID"), Label).Text)
                    'TxtdescripcionColorEditar.Text = Convert.ToString(CType(row.FindControl("Cantidad_Ingreso"), Label).Text)
                    'TxtCantidadIngreso.Text = Convert.ToString(CType(row.FindControl("Precio_Compra"), Label).Text)

                    If (Not ClientScript.IsStartupScriptRegistered("fnEditarColor")) Then

                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "fnEditarColor", "fnEditarColor();", True)

                    End If

                Catch ex As Exception

                    ' Mostrar_Mensaje("Ha ocurrido la Siguiente Excepción: " & ex.Message)

                Finally




                End Try



        End Select

    End Sub

    Private Sub BtnEliminarColor_Click(sender As Object, e As EventArgs) Handles BtnEliminarColor.Click
        Try


            'Ovehiculos.Eliminar(ColorEliminar.Text, Session("usuarios"))
            'ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('se elimino Correctamente');", True)
            'CARGARGRILLA()




        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('No se pudo eliminar');", True)


        End Try

        Response.Redirect("Aspirantes_listar.aspx")


    End Sub

    Private Sub BtnEditarColor_Click(sender As Object, e As EventArgs) Handles BtnEditarColor.Click

        'Dim ods As New DataSet
        Try


            ' Ocompras.EjecutarSp("IN", txtIdColorEditar.Text, TxtdescripcionColorEditar.Text, Session("usuarios"))

            ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('se Actualizo Correctamente el Color');", True)
            CARGARGRILLA()


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert(' No se pudo actualizar');", True)


        End Try
        Response.Redirect("Aspirantes_listar.aspx")

    End Sub

    Private Sub BtnAgregarColor_Click(sender As Object, e As EventArgs) Handles BtnAgregarColor.Click


        Try


            ' Ovehiculos.Agregar(TxtColorAgregar.Text, Session("usuarios"))
            ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('se agrego Correctamente');", True)
            CARGARGRILLA()


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('No se pudo agregar');", True)


        End Try
        Response.Redirect("Aspirantes_listar.aspx")


    End Sub

End Class