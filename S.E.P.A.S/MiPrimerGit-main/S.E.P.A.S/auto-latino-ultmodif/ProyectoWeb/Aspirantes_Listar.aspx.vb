Imports CnSistemas
Public Class Aspirantes_Listar
    Inherits System.Web.UI.Page
    Dim OAspirantes As New CnAspirantes
    Dim OCursos As New CnCursos
    Dim odDataset As New DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            CARGARGRILLA()
            cargoGenero()
            cargoCursos()
            cargoCursos2()
            cargoGenero2()
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
    Public Sub cargoGenero2()
        Dim oGenero As New CnGeneros
        Dim oDs As New DataSet
        oDs = oGenero.TraerTodos()
        DDLGenero2.DataSource = oDs
        DDLGenero2.DataTextField = "DESCRIPCION"
        DDLGenero2.DataValueField = "ID"
        DDLGenero2.DataBind()
    End Sub
    Public Sub cargoCursos()
        Dim oCursos As New CnCursos
        Dim oDs As New DataSet
        oDs = oCursos.TraerTodos()
        DDLCurso.DataSource = oDs
        DDLCurso.DataTextField = "DESCRIPCION"
        DDLCurso.DataValueField = "ID"
        DDLCurso.DataBind()
    End Sub
    Public Sub cargoCursos2()
        Dim oCursos As New CnCursos
        Dim oDs As New DataSet
        oDs = oCursos.TraerTodos()
        DDLCurso2.DataSource = oDs
        DDLCurso2.DataTextField = "DESCRIPCION"
        DDLCurso2.DataValueField = "ID"
        DDLCurso2.DataBind()
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
                    TxtNombreEditar.Text = Convert.ToString(CType(row.FindControl("NOMBRE"), Label).Text)
                    TxtApellidoEditar.Text = Convert.ToString(CType(row.FindControl("APELLIDO"), Label).Text)
                    TxtDniEditar.Text = Convert.ToString(CType(row.FindControl("DNI"), Label).Text)
                    TxtCeEditar.Text = Convert.ToString(CType(row.FindControl("CE"), Label).Text)
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
            'ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('No se pudo eliminar');", True)
            Master.MostrarWarning("No se pudo eliminar. " + ex.Message)

        End Try

        Response.Redirect("Aspirantes_listar.aspx")


    End Sub

    Private Sub BtnEditarColor_Click(sender As Object, e As EventArgs) Handles BtnEditarColor.Click

        'Dim ods As New DataSet
        Try
            If TxtNombre.Text = "" Or TxtApellido.Text = "" Or TxtDni.Text = "" Or TxtCe.Text = "" Then
                ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('Los Campos no pueden estar vacios');", True)
            ElseIf IsNumeric(TxtNombre.Text) = True Or IsNumeric(TxtApellido.Text) = True Then
                MsgBox("No se permiten valores numericos")

            ElseIf IsNumeric(TxtDni.Text) = False Or IsNumeric(TxtCe.Text) = False Then
                ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('Solo se permite valores Numéricos');", True)

            Else
                OAspirantes.EjecutarSp("AC", txtIdColorEditar.Text, TxtNombre.Text, TxtApellido.Text, TxtDni.Text, TxtCe.Text, DDLGenero.Text, DDLCurso.Text, Session("usuarios"))

                ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('se Actualizo Correctamente el Color');", True)
                CARGARGRILLA()
            End If

        Catch ex As Exception
            'ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert(' No se pudo actualizar');", True)
            Master.MostrarWarning("No se pudo actualizar. " + ex.Message)

        End Try


    End Sub

    Private Sub BtnAgregarColor_Click(sender As Object, e As EventArgs) Handles BtnAgregarColor.Click

        Try
            If TxtNombre.Text = "" Or TxtApellido.Text = "" Or TxtDni.Text = "" Or TxtCe.Text = "" Then
                LblNombre.Text = "Complete los Campos vacios"
            ElseIf IsNumeric(TxtNombre.Text) = True Or IsNumeric(TxtApellido.Text) = True Then
                ' ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('Solo se Permite texto');", True)
                LblNombre.Text = "Solo se Permite texto"

            ElseIf IsNumeric(TxtDni.Text) = False Or IsNumeric(TxtCe.Text) = False Then
                ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('Solo se permite valores Numéricos');", True)
            Else
                OAspirantes.Agregar(TxtNombre.Text, TxtApellido.Text, TxtDni.Text, TxtCe.Text, DDLCurso.SelectedValue, DDLGenero.SelectedValue, Session("usuarios"))
                ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('se agrego Correctamente');", True)
                CARGARGRILLA()
            End If

        Catch ex As Exception
            ' ClientScript.RegisterStartupScript(Me.GetType, "msg", "alert('No se pudo agregar');", True)
            Master.MostrarWarning("No se pudo agregar. " + ex.Message)

        End Try
        Response.Redirect("Aspirantes_listar.aspx")


    End Sub

End Class