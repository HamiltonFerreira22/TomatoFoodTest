
namespace TomatoFoodTest.Model.ResponseSchema
{
    public class RegisterSchema
    {
        public static JSchema RegisterJson()
        {
            JSchema schema = JSchema.Parse(@"{
    '$schema': 'http://json-schema.org/draft-07/schema',
    'type': 'object',
    'required': [
        'role',
        '_id',
        'name',
        'email',
        'password',
        'date',
        '__v'
    ],
    'properties': {
        'role': {
            'type': 'string'
        },
        '_id': {
            'type': 'string'
        },
        'name': {
            'type': 'string'
        },
        'email': {
            'type': 'string'
        },
        'password': {
            'type': 'string'
        },
        'date': {
            'type': 'string'
        },
        '__v': {
            'type': 'integer'
        }
    }
}");
            return schema;
        }
    }
}
