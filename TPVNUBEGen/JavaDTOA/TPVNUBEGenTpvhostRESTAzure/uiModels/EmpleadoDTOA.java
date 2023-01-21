
package TPVNUBEGenTpvhostRESTAzure.uiModels.DTOA;

import TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.*;
import TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.utils.*;
import TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class EmpleadoDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private String apellidos;
	public String getApellidos () { return apellidos; }
	public void setApellidos (String apellidos) { this.apellidos = apellidos; }
	
	private String pass;
	public String getPass () { return pass; }
	public void setPass (String pass) { this.pass = pass; }
	
	private String foto;
	public String getFoto () { return foto; }
	public void setFoto (String foto) { this.foto = foto; }
	
	private String dni;
	public String getDni () { return dni; }
	public void setDni (String dni) { this.dni = dni; }
	
	private String email;
	public String getEmail () { return email; }
	public void setEmail (String email) { this.email = email; }
	
	
	/* Rol: Empleado o--> Pedido */
	private ArrayList<PedidoDTOA> comandas;
	public ArrayList<PedidoDTOA> getComandas () { return comandas; }
	public void setComandas (ArrayList<PedidoDTOA> comandas) { this.comandas = comandas; }

	/* Rol: Empleado o--> Negocio */
	private NegocioDTOA negocioEmpleado;
	public NegocioDTOA getNegocioEmpleado () { return negocioEmpleado; }
	public void setNegocioEmpleado (NegocioDTOA negocioEmpleado) { this.negocioEmpleado = negocioEmpleado; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public EmpleadoDTOA ()
	{
		// Empty constructor
	}
	
	@Override
	public void setFromJSON (JSONObject json)
	{
		try
		{
			if (!JSONObject.NULL.equals(json.opt("Id")))
			{
				this.id = (Integer) json.opt("Id");
			}
			

			if (!JSONObject.NULL.equals(json.opt("Nombre")))
			{
			 
				this.nombre = (String) json.opt("Nombre");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Apellidos")))
			{
			 
				this.apellidos = (String) json.opt("Apellidos");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Pass")))
			{
			 
				this.pass = (String) json.opt("Pass");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Foto")))
			{
			 
				this.foto = (String) json.opt("Foto");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Dni")))
			{
			 
				this.dni = (String) json.opt("Dni");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Email")))
			{
			 
				this.email = (String) json.opt("Email");
			 
			}
			

			JSONObject jsonComandas = json.optJSONObject("Comandas");
			if (jsonComandas != null)
			{
				PedidoDTOA tmp = new PedidoDTOA();
				tmp.setFromJSON(jsonComandas);
				this.comandas = tmp;
			}


			JSONObject jsonNegocioEmpleado = json.optJSONObject("NegocioEmpleado");
			if (jsonNegocioEmpleado != null)
			{
				NegocioDTOA tmp = new NegocioDTOA();
				tmp.setFromJSON(jsonNegocioEmpleado);
				this.negocioEmpleado = tmp;
			}

			
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	
	public JSONObject toJSON ()
	{
		JSONObject json = new JSONObject();
		
		try
		{
			if (this.id != null){
				json.put("Id", this.id);
			}
			
		
		  if (this.nombre != null)
			json.put("Nombre", this.nombre);
		
		
		  if (this.apellidos != null)
			json.put("Apellidos", this.apellidos);
		
		
		  if (this.pass != null)
			json.put("Pass", this.pass);
		
		
		  if (this.foto != null)
			json.put("Foto", this.foto);
		
		
		  if (this.dni != null)
			json.put("Dni", this.dni);
		
		
		  if (this.email != null)
			json.put("Email", this.email);
		
			

			if (this.comandas != null)
			{
				json.put("Comandas", this.comandas.toJSON());
			}


			if (this.negocioEmpleado != null)
			{
				json.put("NegocioEmpleado", this.negocioEmpleado.toJSON());
			}

			
		}
		catch (JSONException e)
		{
			e.printStackTrace();
		}
		
		return json;
	}
	
	@Override 
	public IDTO toDTO ()
	{
		EmpleadoDTO dto = new EmpleadoDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setApellidos (this.getApellidos());

	dto.setPass (this.getPass());

	dto.setFoto (this.getFoto());

	dto.setDni (this.getDni());

	dto.setEmail (this.getEmail());

		
		
		// Roles
					// TODO: from DTOA [ Comandas ] (dataType : ArrayList<PedidoDTOA>) to DTO [ Comanda ]
					// TODO: from DTOA [ NegocioEmpleado ] (dataType : NegocioDTOA) to DTO [ Negocio ]
		
		
		return dto;
	}

	// endregion
}

	