
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
public class DuenyoRegistradoDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private String telefono;
	public String getTelefono () { return telefono; }
	public void setTelefono (String telefono) { this.telefono = telefono; }
	
	private String email;
	public String getEmail () { return email; }
	public void setEmail (String email) { this.email = email; }
	
	private String dni;
	public String getDni () { return dni; }
	public void setDni (String dni) { this.dni = dni; }
	
	private String pass;
	public String getPass () { return pass; }
	public void setPass (String pass) { this.pass = pass; }
	
	private String foto;
	public String getFoto () { return foto; }
	public void setFoto (String foto) { this.foto = foto; }
	
	private String apellidos;
	public String getApellidos () { return apellidos; }
	public void setApellidos (String apellidos) { this.apellidos = apellidos; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public DuenyoRegistradoDTOA ()
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

			if (!JSONObject.NULL.equals(json.opt("Telefono")))
			{
			 
				this.telefono = (String) json.opt("Telefono");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Email")))
			{
			 
				this.email = (String) json.opt("Email");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Dni")))
			{
			 
				this.dni = (String) json.opt("Dni");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Pass")))
			{
			 
				this.pass = (String) json.opt("Pass");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Foto")))
			{
			 
				this.foto = (String) json.opt("Foto");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Apellidos")))
			{
			 
				this.apellidos = (String) json.opt("Apellidos");
			 
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
		
		
		  if (this.telefono != null)
			json.put("Telefono", this.telefono);
		
		
		  if (this.email != null)
			json.put("Email", this.email);
		
		
		  if (this.dni != null)
			json.put("Dni", this.dni);
		
		
		  if (this.pass != null)
			json.put("Pass", this.pass);
		
		
		  if (this.foto != null)
			json.put("Foto", this.foto);
		
		
		  if (this.apellidos != null)
			json.put("Apellidos", this.apellidos);
		
			
			
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
		DuenyoDTO dto = new DuenyoDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setTelefono (this.getTelefono());

	dto.setEmail (this.getEmail());

	dto.setDni (this.getDni());

	dto.setPass (this.getPass());

	dto.setFoto (this.getFoto());

	dto.setApellidos (this.getApellidos());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	